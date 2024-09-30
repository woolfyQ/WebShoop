using Core.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;

namespace WebShop.API
{
    public sealed class TokenProvider(IConfiguration configuration)
    {
        public string Create(UserDTO userDTO)
        {
            string secretKey = configuration["JWT:Secret"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                new Claim(JwtRegisteredClaimNames.Sub, userDTO.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userDTO.Email),
                ]),
                Expires = DateTime.UtcNow.AddSeconds(configuration.GetValue<int>("JWT:ExpirationInMinutes")),
                SigningCredentials = credential,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };
            var Handler = new JsonWebTokenHandler();
            string token = Handler.CreateToken(tokenDescriptor);
            return token;

        }
    }
}
