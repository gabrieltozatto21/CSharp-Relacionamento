using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class EfetuaResetRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ReSenha { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
