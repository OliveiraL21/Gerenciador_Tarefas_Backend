using Application.DTO.StatusDTO;
using Domain.Entidades;
using System;

namespace Application.DTO.Tarefas.Listagem
{
    public class TarefaListagemDTO
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string HorarioInicio { get; set; }

        public string HorarioFim { get; set; }

        public string Duracao { get; set; }

        public StatusListagemDTO Status { get; set; }

        public Projeto? Projeto { get; set; }

        public string Descricao { get; set; }

        public string? Observacao { get; set; }
    }
}
