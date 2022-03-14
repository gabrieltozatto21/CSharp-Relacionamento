using Microsoft.AspNetCore.Authorization;

namespace FilmesApi.Authorization
{
    public class IdadeMinimaRequirements : IAuthorizationRequirement
    {
        public int idadeMinima { get; set; }

        public IdadeMinimaRequirements(int idadeMinima)
        {
            this.idadeMinima = idadeMinima;
        }
    }
}
