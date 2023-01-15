using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Projeto : BaseEntity
    {
        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }

        public int ClienteId { get; set; }

        public  Cliente Cliente { get; set; }

        public List<Tarefa> Tarefas { get; set; }

    }
}
