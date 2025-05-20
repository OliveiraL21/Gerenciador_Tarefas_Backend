using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ProjetoEntity : BaseEntity
    {
        public string Descricao { get; set; }

        public DateTimeOffset DataInicio { get; set; }

        public DateTimeOffset DataFim { get; set; }

        public int StatusId { get; set; }

        public StatusEntity Status { get; set; }

        public int ClienteId { get; set; }

        public  Cliente Cliente { get; set; }

        public List<TarefaEntity> Tarefas { get; set; }

    }
}
