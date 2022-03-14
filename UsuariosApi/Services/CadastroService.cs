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
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private UserDbContext _context;
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(UserDbContext context, IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
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
            CustomIdentityUser identityUser = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(identityUser, usuarioDto.Senha);

            //adicionando uma role regular para todo usuario que for criado
            _userManager.AddToRoleAsync(identityUser, "regular");

            //criação de usuario admin e role admin de uma maneira não eficiente
            //var createRoleResult = _roleManager
            //    .CreateAsync(new IdentityRole<int>("admin")).Result;
            //var usuarioRoleResult = _userManager
            //    .AddToRoleAsync(identityUser, "admin").ToResult();

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
