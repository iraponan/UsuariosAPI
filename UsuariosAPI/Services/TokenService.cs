﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services {
    public class TokenService {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public String GenerateToken(Usuario usuario) {
            Claim[] claims = new Claim[] { 
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            SymmetricSecurityKey chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                    expires : DateTime.Now.AddMinutes(10),
                    claims : claims,
                    signingCredentials : signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
