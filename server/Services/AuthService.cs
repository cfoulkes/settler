using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace server.Services;

public class AuthService : IAuthService
{
    const int keySize = 64;
    const int iterations = 350000;
    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    private readonly DataContext context;

    public AuthService(DataContext context)
    {
        this.context = context;
    }

    public async Task<User> CreateUser(string username, string password)
    {
        Console.WriteLine("AuthService.CreateUser");
        var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (existingUser != null)
        {
            throw new InvalidOperationException();
        }

        CreatePasswordHash(password, out string passwordHash, out string passwordSalt);
        Console.WriteLine($"password {password} hash {passwordHash}   salt {passwordSalt}");
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

    public async Task<User?> Login(string username, string password)
    {
        Console.WriteLine("AuthService.Login");
        var user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user == null)
        {
            return null;
        }

        var passwordChecked = CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt);

        if (!passwordChecked)
        {
            return null;
        }

        return user;
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

    private string CreateRandomToken(int length = 32)
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(2 * length));
    }
}
