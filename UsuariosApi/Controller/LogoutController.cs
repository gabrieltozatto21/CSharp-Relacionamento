using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Services;

namespace UsuariosApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogoutController(LogoutService loginService)
        {
            _logoutService = loginService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result resultado = _logoutService.DeslogaUsuario();
            if(resultado.IsFailed) return Unauthorized(resultado.Reasons);
            return Ok(resultado.Reasons);
        }

    }
}
