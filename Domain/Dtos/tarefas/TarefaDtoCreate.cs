using Domain.Dtos.status;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.tarefas
{
    public class TarefaDtoCreate
    {
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Horario final é campo Obrigatório")]
        public DateTime horarioFim { get; set; }

        [Required(ErrorMessage = "Horario incial é um campo Obrigatório")]
        public DateTime horarioInicio { get; set; }

        [Required(ErrorMessage = "Duracao é um campo Obrigatório")]
        public string Duracao { get; set; }

        public StatusDto Status { get; set; }

        public Guid? ProjetoId { get; set; }

        [Required(ErrorMessage = "Descrição é um campo Obrigatório")]
        public string Descricao { get; set; }

        public string? Observacao { get; set; }
    }
}
