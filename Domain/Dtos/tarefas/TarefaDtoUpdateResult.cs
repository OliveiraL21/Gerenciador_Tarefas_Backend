using Application.DTO.Projetos;
using Domain.Dtos.status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.tarefas
{
    public class TarefaDtoUpdateResult
    {
        public Guid Id { get; set; }
        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioFim { get; set; }

        public DateTime Duracao { get; set; }

        public DateTime Data { get; set; }

        public string Observacao { get; set; }

        public string Descricao { get; set; }

        public Guid ProjetoId { get; set; }

        public ProjetoDtoSimple Projeto { get; set; }

        public Guid StatusId { get; set; }

        public StatusDto Status { get; set; }
    }
}
