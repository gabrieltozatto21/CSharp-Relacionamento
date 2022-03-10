using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class SolicitaSenhaRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
