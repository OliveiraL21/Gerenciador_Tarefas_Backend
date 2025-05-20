using Domain.Entidades;
using System.ComponentModel.DataAnnotations;
using System;

namespace Application.DTO.Tarefas.Update
{
    public class UpdateTarefaDTO
    {
        [Required]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]


        public string horarioFim { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string horarioInicio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Duracao { get; set; }

        public StatusEntity Status { get; set; }

        public int? ProjetoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Descricao { get; set; }

        public string? Observacao { get; set; }
    }
}
