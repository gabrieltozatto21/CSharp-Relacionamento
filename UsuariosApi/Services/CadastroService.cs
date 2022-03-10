using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Data.Requests;
using UsuariosAPI.Data;
using UsuariosAPI.Data.Dtos.Usuarios;
using UsuariosAPI.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private UserDbContext _context;
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(UserDbContext context, IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(identityUser, usuarioDto.Senha);
            var createRoleResult = _roleManager
                .CreateAsync(new IdentityRole<int>("admin")).Result;
            var usuarioRoleResult = _userManager
                .AddToRoleAsync(identityUser, "admin").ToResult();

            if (resultIdentity.Result.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;

                var encodedCode = HttpUtility.UrlEncode(code);

                Console.WriteLine(encodedCode);
                _emailService.EnviarEmail(
                        new [] { identityUser.Email},
                        "Link de Ativação",
                        identityUser.Id,
                        encodedCode
                    );
                return Result.Ok().WithSuccess(encodedCode);   
            }
            return Result.Fail("Falha ao cadastrar user!");
        }

        public Result AtivaConta(AtivaContaRequest request)
        {
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = _userManager
                .ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;
            if (identityResult.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao ativar conta de usuário!");
        }


    }
}
