using Application.DTO.StatusDTO;
using Domain.Entidades;
using System;

namespace Application.DTO.Tarefas.Listagem
{
    public class TarefaListagemDTO
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public DateTime HorarioInicio { get; set; }

        public DateTime HorarioFim { get; set; }

        public string Duracao { get; set; }

        public StatusListagemDTO Status { get; set; }

        public ProjetoEntity? Projeto { get; set; }

        public string Descricao { get; set; }

        public string? Observacao { get; set; }
    }
}
