using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Lagradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}
