using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace AuthApi.Service
{
    public  class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string GeradorDeToken(Usuario usuario)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenSecret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
             {
                 Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NomeUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Roles.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email.ToString())
                }),
                 Expires = DateTime.UtcNow.AddHours(2),
                 SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
             };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
