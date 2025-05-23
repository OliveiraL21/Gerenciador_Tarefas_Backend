using Domain.Dtos.cliente;
using Domain.Dtos.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.projeto
{
    public class ProjetoDtoUpdateResult
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public StatusDto Status { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
