using Domain.Dtos.cliente;
using Domain.Dtos.status;
using Domain.Entidades;
using System;

namespace Application.DTO.Projetos
{
    public class ProjetoDtoListagem
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public StatusDto status { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public ClienteDto Cliente { get; set; }
    }
}
