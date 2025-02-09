using AuthService.Entities;
using AuthService.Repositories;
using AuthService.Services.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public sealed class TokenProvider(IConfiguration configuration, IRoleRepository roleRepository) : ITokenProvider
    {
        public async Task<string> Create(User user)
        {
            string secretKey = configuration["JwtSettings:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var role = await roleRepository.GetRoleByIdAsync(user.RoleId);

            var identity = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role,  role.Name)
                ]);

            var tokenDescriptor = new SecurityTokenDescriptor //проблеми з клеймами вони називаються чомусь як посилання на щось 
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("JwtSettings:ExpirationInMinutes")),
                SigningCredentials = credentials,
                Issuer = configuration["JwtSettings:Issuer"],
                Audience = configuration["JwtSettings:Audience"]
            };

            var handler = new JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
