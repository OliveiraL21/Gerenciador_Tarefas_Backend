using Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System;

namespace Application.DTO.Tarefas.Create
{
    public class CreateTarefaDTO
    {
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]


        public DateTime horarioFim { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime horarioInicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Duracao { get; set; }

        public StatusEntity Status { get; set; }

        public int? ProjetoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        public string? Observacao { get; set; }
    }
}
