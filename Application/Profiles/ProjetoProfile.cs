using Application.DTO.Projetos;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<Projeto, ProjetoListagemDTO>();
            CreateMap<ProjetoListagemDTO, Projeto>();
            CreateMap<Projeto, ProjetoListagemSimplesDTO>();
            CreateMap<Projeto, UpdateProjetoDTO>();
            CreateMap<UpdateProjetoDTO, Projeto>();
        }
    }
}
