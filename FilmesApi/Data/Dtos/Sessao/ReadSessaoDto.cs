using FilmesApi.Models;
using System;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public virtual Filme Filme { get; set; }
        public virtual Cinema Cinema { get; set; }
        public DateTime HorarioEncerramento { get; set; }
        public DateTime HorarioInicio { get; set; }
    }
}
