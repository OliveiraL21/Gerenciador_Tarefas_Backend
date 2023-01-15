using System;

namespace Domain.Entidades
{
    public class Tarefa : BaseEntity
    {

        public TimeSpan HorarioInicio { get; set; }

        public TimeSpan HorarioFim { get; set; }

        public TimeSpan Duracao { get; set; }

        public DateTime Data { get; set; }

        public  string Observacao { get; set; }

        public string Descricao { get; set; }

        public int ProjetoId { get; set; }

        public Projeto Projeto { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}