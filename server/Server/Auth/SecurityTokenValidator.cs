using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Server.Auth
{
    public class SecurityTokenValidator : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }

        public bool CanReadToken(string securityToken) => true;

        private readonly JwtSecurityTokenHandler _tokenHandler;

        public SecurityTokenValidator()
        {
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public ClaimsPrincipal ValidateToken(
            string securityToken,
            TokenValidationParameters validationParameters,
            out SecurityToken validatedToken
        )
        {
            validatedToken = _tokenHandler.ReadJwtToken(securityToken);

            var identity = new CustomIdentity(null, "custom authentication");
            identity.UserId = 123;
            identity.AgencyId = 345;

            var claimsPrincipal = new ClaimsPrincipal(identity);
            return claimsPrincipal;
        }
    }
}
