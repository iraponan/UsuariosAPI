using Microsoft.AspNetCore.Authorization;

namespace UsuariosAPI.Authorization {
    public class IdadeMinima : IAuthorizationRequirement {
        public int idade { get; set; }

        public IdadeMinima(int idade) {
            this.idade = idade;
        }
    }
}
