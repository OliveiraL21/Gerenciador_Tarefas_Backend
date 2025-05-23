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

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public Guid StatusId { get; set; }

        public StatusEntity Status { get; set; }

        public Guid ClienteId { get; set; }

        public  ClienteEntity Cliente { get; set; }

        public IEnumerable<TarefaEntity> Tarefas { get; set; }

    }
}
