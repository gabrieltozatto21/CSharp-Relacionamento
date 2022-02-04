using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "O campo de Lagradouro é obrigatório")]
        public string Lagradouro { get; set; }
        [Required(ErrorMessage = "O campo de Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo de Numero é obrigatório")]
        public int Numero { get; set; }
    }
}
