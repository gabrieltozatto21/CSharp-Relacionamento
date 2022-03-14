using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _singinManager;
        public LogoutService(SignInManager<CustomIdentityUser> signinManager)
        {
            _singinManager = signinManager;
        }

        public Result DeslogaUsuario()
        {
            var resultadoIdentity = _singinManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Logout is failure!");
        }
    }
}
