using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PropertyManagementApi.Application.Contracts.Authentication;

namespace PropertyManagementApi.Application.Services.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly JwtSettings _settings;

        public JwtGenerator(IOptions<JwtSettings> jwtOptions)
        {
            _settings = jwtOptions.Value;
        }

        public string GenerateJwtToken(int idUsuario, string correo, string nombre)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_settings.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, idUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, correo)
            };

            var securityToken = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
