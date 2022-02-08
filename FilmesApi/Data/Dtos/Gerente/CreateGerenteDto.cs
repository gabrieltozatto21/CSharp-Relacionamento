using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage = "Nome é requerido!")]
        public string Nome { get; set; }
    }
}
