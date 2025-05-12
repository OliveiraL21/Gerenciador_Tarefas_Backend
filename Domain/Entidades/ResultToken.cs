using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ResultToken
    {
        public string Token { get; set; }
        public int UsuarioId { get; set; }
        public string Message { get; set; }
        public bool IsFail { get; set; }

        public bool Authenticated { get; set; }

    }
}
