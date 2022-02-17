using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;
using UsuariosAPI.Data.Dtos.Usuarios;

namespace UsuariosApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _usuarioService;

        public CadastroController(CadastroService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _usuarioService.CadastraUsuario(createDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
