using Domain.Entidades;
using Domain.Services.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Login
{
    public class TokenService : ITokenService
    {
        public Token gerarToken(IdentityUser<int> identityUser)
        {
            Claim[] direitos = new Claim[]
            {
                new Claim ("username", identityUser.UserName),
                new Claim("id", identityUser.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    claims: direitos,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token( tokenString );
        }
    }
}
