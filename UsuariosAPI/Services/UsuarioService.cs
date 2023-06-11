using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services {
    public class UsuarioService {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService) {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDto dto) {
            Usuario usuario = _mapper.Map<Usuario>(dto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Senha);
            if (!resultado.Succeeded) {
                throw new ApplicationException("Falha ao cadastrar usuário!");
            }
        }

        internal async Task Login(LoginUsuarioDto dto) {
            SignInResult resultado = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Senha, false, false);
            if (!resultado.Succeeded) {
                throw new ApplicationException("Usuário não autenticado!");
            }

            
        }
    }
}
