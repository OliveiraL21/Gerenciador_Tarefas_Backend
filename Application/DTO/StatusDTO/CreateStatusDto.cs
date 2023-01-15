using System.ComponentModel.DataAnnotations;

namespace Application.DTO.StatusDTO
{
    public class CreateStatusDto
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
    }
}
