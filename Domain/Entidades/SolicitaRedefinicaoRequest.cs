using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class SolicitaRedefinicaoRequest
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }
    }
}
