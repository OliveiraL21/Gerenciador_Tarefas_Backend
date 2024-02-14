using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.User
{
    public class UserDtoUpdate 
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo username é obrigatório")]
        public string username { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório")]
        public string Email { get; set; }

        public string phoneNumber { get; set; }

        public string profileImageUrl { get; set; }
    }
}

