using Application.DTO.Projetos;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<ProjetoEntity, ProjetoListagemDTO>();
            CreateMap<ProjetoListagemDTO, ProjetoEntity>();
            CreateMap<ProjetoEntity, ProjetoListagemSimplesDTO>();
            CreateMap<ProjetoEntity, UpdateProjetoDTO>();
            CreateMap<UpdateProjetoDTO, ProjetoEntity>();
        }
    }
}
