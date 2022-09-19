using Abstracciones;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaServicios
{
    public interface ITokenHandlerService
    {
        string GenerateJwtToken(ITokenParameters parameters);
    }
    public class TokenHandlerService : ITokenHandlerService
    {
        private readonly JWT_Configuration _jwtConfig;
        public TokenHandlerService(IOptionsMonitor<JWT_Configuration> options)
        {
            _jwtConfig = options.CurrentValue; 
        }

        public string GenerateJwtToken(ITokenParameters pars)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", pars.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, pars.UserName ),
                    new Claim(JwtRegisteredClaimNames.Email, pars.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
