
using Demo06.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo06.Models
{
    public class Pessoa
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Cpf obrigatorio")]
        [CpfValidation(ErrorMessage = "Cpf Invalido")]
        public string Cpf { get; set; }
        [MaxLength(5, ErrorMessage = "Máximo 5")]
        public string Nome { get; set; }
    }
}
