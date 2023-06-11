using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services {
    public class TokenService {
        public void GenerateToken(Usuario usuario) {
            Claim[] claims = new Claim[] { 
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };

            SymmetricSecurityKey chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SfR3467FGdfgg57809123sdfvbfghASar"));

            SigningCredentials signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    expires : DateTime.Now.AddMinutes(10),
                    claims : claims,
                    signingCredentials : signingCredentials
                );
        }
    }
}
