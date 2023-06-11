using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase {

        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuarioController(IMapper mapper, UserManager<Usuario> userManager) {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto) {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Senha);
            if (resultado.Succeeded) {
                return Ok("Usuário " + dto.UserName + " Cadastrado!");
            }

            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }
}
