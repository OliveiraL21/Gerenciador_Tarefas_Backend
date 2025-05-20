using System;

namespace Domain.Entidades
{
    public class TarefaEntity : BaseEntity
    {

        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioFim { get; set; }

        public DateTime Duracao { get; set; }

        public DateTime Data { get; set; }

        public  string Observacao { get; set; }

        public string Descricao { get; set; }

        public Guid ProjetoId { get; set; }

        public ProjetoEntity Projeto { get; set; }

        public Guid StatusId { get; set; }

        public StatusEntity Status { get; set; }
    }
}