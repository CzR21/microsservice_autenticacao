using Microsoft.IdentityModel.Tokens;
using Microsservice_Domain.Configuration;
using Microsservice_Domain.Entites;
using Microsservice_Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Microsservice_Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTConfiguration _jwtConfiguration;

        public TokenService(JWTConfiguration jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration;
        }

        public TokenResponseModel GenerateToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfiguration.Secret);

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
            };

            var expiraEm = DateTime.UtcNow.AddHours(8);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = expiraEm,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var jwtToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateToken(35);

            return new TokenResponseModel()
            {
                IdUsuario = usuario.Id,
                NomeUsuario = usuario.Nome,
                Token = jwtToken,
                RefreshToken = refreshToken,
            };
        }

        private static string GenerateToken(int length, bool? apenasNumeros = false)
        {
            var random = new Random();
            var chars = "ABCDEFGHHIJKLMNOPQRSTUVWXYZ0123456789";
            if (apenasNumeros == true)
            {
                chars = "0123456789";
            }

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
