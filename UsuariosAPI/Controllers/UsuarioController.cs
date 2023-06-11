using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers {

    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase {

        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService) {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto) {
            await _usuarioService.Cadastrar(dto);
            return Ok("Usuário " + dto.UserName + " Cadastrado Com Sucesso!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto) {
            await _usuarioService.Login(dto);
            return Ok("Usuário " + dto.UserName + " autenticado!");
        }
    }
}
