using Domain.Entidades;
using System;

namespace Application.DTO.Projetos
{
    public class UpdateProjetoDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public Status Status { get; set; }

        public Cliente Cliente { get; set; }
    }
}
