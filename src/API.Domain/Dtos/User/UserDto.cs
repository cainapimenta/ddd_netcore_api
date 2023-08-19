﻿using System.ComponentModel.DataAnnotations;

namespace API.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracateres")]
        public string Email { get; set; }
    }
}
