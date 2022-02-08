using System;

namespace FilmesApi.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioEncerramento { get; set; }
    }
}
