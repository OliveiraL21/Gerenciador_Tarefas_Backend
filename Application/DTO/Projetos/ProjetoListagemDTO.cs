using Domain.Entidades;
using System;

namespace Application.DTO.Projetos
{
    public class ProjetoListagemDTO
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public StatusEntity status { get; set; }

        public string Data_Inicio { get; set; }

        public string Data_Fim { get; set; }

        public Cliente Cliente { get; set; }
    }
}
