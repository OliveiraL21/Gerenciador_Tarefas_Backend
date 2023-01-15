using Domain.Entidades;
using System;

namespace Application.DTO.Projetos
{
    public class ProjetoListagemDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public Status status { get; set; }

        public DateTime Data_Inicio { get; set; }

        public DateTime Data_Fim { get; set; }

        public Cliente Cliente { get; set; }
    }
}
