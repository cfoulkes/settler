using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Server.Services;

public class AuthService : IAuthService
{
    const int keySize = 64;
    const int iterations = 350000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    private readonly DataContext context;
    private readonly IConfiguration config;

    public AuthService(DataContext context, IConfiguration config)
    {
        this.context = context;
        this.config = config;
    }

    public async Task<User> CreateUser(string username, string password)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (existingUser != null)
        {
            throw new InvalidOperationException();
        }

        CreatePasswordHash(password, out string passwordHash, out string passwordSalt);

        var user = new User
        {
            Username = username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<string?> Login(string username, string password)
    {
        var user = await context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            return null;
        }

        var passwordChecked = CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt);

        if (!passwordChecked)
        {
            return null;
        }

        string tokenString = GenerateJwtToken(user);
        Console.WriteLine($"token {tokenString}");

        return tokenString;
    }

    private void CreatePasswordHash(
        string password,
        out string passwordHash,
        out string passwordSalt
    )
    {
        var salt = RandomNumberGenerator.GetBytes(keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize
        );

        passwordSalt = Convert.ToHexString(salt);
        passwordHash = Convert.ToHexString(hash);
    }

    private bool CheckPasswordHash(string password, string passwordHash, string passwordSalt)
    {
        var salt = Convert.FromHexString(passwordSalt);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
            hashAlgorithm,
            keySize
        );

        Console.WriteLine($"password {password}");
        Console.WriteLine($"passwordHash {passwordHash}");
        Console.WriteLine($"calcHash {Convert.ToHexString(hash)}");

        return passwordHash.Equals(Convert.ToHexString(hash));
    }

    private string GenerateJwtToken(User user)
    {
        var issuer = config["Jwt:Issuer"];
        var audience = config["Jwt:Audience"];
        var key = config["Jwt:Key"];

        var claims = new List<Claim> { new(JwtRegisteredClaimNames.Sub, user.Id.ToString()) };

        user.UserRoles
            .ToList()
            .ForEach(ur =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ur.Role.Description));
            });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        Console.WriteLine($"token {tokenValue}");
        return tokenValue;
    }

    private string CreateRandomToken(int length = 32)
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(2 * length));
    }
}
