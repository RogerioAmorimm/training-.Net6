
using Microservices.Domain.Entities.Token;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microservices.Domain.Entities.User;

namespace Microservices.Services.TokenService
{
    public class TokenService : ITokenService
    {
        public Token CreateToken(CustomIdentityUser user, string role)
        {
            var userRights = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(SecurityKeyAuth.GetKey())
                );

            var credentials = new SigningCredentials(key,
                                                     SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(8)
                );

            return new Token(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
