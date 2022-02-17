using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
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

        public CadastroService(UserDbContext context, IMapper mapper, UserManager<IdentityUser<int>> userManager )
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDto);
            IdentityUser<int> identityUser = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(identityUser, usuarioDto.Senha);
            if (resultIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar user!");

        }


    }
}
