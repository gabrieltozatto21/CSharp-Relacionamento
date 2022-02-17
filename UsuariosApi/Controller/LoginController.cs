using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest loginRequest)
        {
            Result resultado = _loginService.LogaUsuario(loginRequest);
            if (resultado.IsFailed) return Unauthorized(resultado.Reasons);
            return Ok(resultado.Reasons);
        }
    }
}
