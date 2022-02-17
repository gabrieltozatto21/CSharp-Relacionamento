using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _singinManager;
        public LogoutService(SignInManager<IdentityUser<int>> signinManager)
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
