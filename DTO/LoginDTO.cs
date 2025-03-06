﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Filmes_senai.DTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "O Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é Obrigatória! ")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo 6 caracteres e no máximo 60")]
        public string? Senha { get; set; }
    }
}
