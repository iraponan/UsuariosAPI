using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos {
    public class CreateUsuarioDto {
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmeSenha { get; set; }
    }
}
