using Domain.Dtos.cliente;
using Domain.Dtos.status;
using Domain.Entidades;
using System;

namespace Domain.Dtos.projeto
{
    public class ProjetoDtoUpdate
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public StatusDto Status { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
