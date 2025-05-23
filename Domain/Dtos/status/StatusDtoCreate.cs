using System.ComponentModel.DataAnnotations;

namespace Application.DTO.StatusDTO
{
    public class StatusDtoCreate
    {
        [Required(ErrorMessage = "Descrição é um campo obrigatório")]
        public string Descricao { get; set; }
    }
}
