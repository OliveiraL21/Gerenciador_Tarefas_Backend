using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Cliente : BaseEntity
    {

        public string RazaoSocial { get; set; }

        public string Cnpj { get; set; }    

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public List<Projeto>? Projetos { get; set; }
    }
}