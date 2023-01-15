using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Tarefas.Create.ProjetoDTO
{
    public class ProjetoCreateDto
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Id { get; set; }
    }
}
