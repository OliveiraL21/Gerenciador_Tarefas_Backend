using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Status : BaseEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<Projeto> Projetos { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}