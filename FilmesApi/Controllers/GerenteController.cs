using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Gerente;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public GerenteController(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;  
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto )
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return Ok(gerente);
        }

        [HttpGet("{id}")]
        public IActionResult PesquisaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente == null) return NotFound();

            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);
            return Ok(gerenteDto);
        }




    }
}
