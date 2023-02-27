using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class AtivaRequest
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public string CodigoAtivacao { get; set; }
    }
}
