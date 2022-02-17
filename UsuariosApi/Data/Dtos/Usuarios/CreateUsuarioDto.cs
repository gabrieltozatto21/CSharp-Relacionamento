﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos.Usuarios
{
    public class CreateUsuarioDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ReSenha { get; set; }
    }
}
