using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.ExternalServices.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _config { get; }

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public TokenDTO CreateToken(TokenItemsDTO dto)
        {
            ///TODO: Claimleri duzenle
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.user.Id ));
            claims.Add(new Claim("UserName", dto.user.UserName));
            claims.Add(new Claim("Name", dto.user.Name));
            claims.Add(new Claim("Surname", dto.user.Surname));
            claims.Add(new Claim(ClaimTypes.Role, dto.role));
            DateTime expiresTime = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:ExpireMin"]));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Salt"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwt = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                DateTime.UtcNow,
                expiresTime,
                credentials);
            JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
            var token=handler.WriteToken(jwt);

            return new TokenDTO
            {
                expireTime= expiresTime,
                token = token
            };
        }
    }
}
