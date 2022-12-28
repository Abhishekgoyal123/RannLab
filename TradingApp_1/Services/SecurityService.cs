using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TradingApp_1.Models;

namespace TradingApp_1.Services
{
    public class SecurityService
    {
        IConfiguration _configuration;

        public SecurityService(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public async Task<SecureResponse> AuthUser(Registeruser user)
        {
            SecureResponse secureResponse = new SecureResponse();

            var secretKey = Convert.FromBase64String(_configuration["JWTCoreSettings:SecretKey"]);

            var expiryTimeSpan = Convert.ToInt32(_configuration["JWTCoreSettings:ExpiryInMinuts"]);

            var securityTokenDescription = new SecurityTokenDescriptor()
            {
                Issuer = null,
                Audience = null,

                Subject = new ClaimsIdentity(new List<Claim>
                    {
                        new Claim("userEmail", user.Email, ToString()),
                    }),

                Expires = DateTime.UtcNow.AddMinutes(expiryTimeSpan),
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtHandler = new JwtSecurityTokenHandler();

            var jwtoken = jwtHandler.CreateJwtSecurityToken(securityTokenDescription);

            secureResponse.UserName = user.Email;
            secureResponse.Token = jwtHandler.WriteToken(jwtoken);
            
            return secureResponse;
        }
    }
}
