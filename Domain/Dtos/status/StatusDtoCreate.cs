using System.ComponentModel.DataAnnotations;

namespace Application.DTO.StatusDTO
{
    public class StatusDtoCreate
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
    }
}
