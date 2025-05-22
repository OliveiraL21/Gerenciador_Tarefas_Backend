using Application.DTO.Projetos;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class ProjetoProfile : Profile
    {
        public ProjetoProfile()
        {
            CreateMap<ProjetoEntity, ProjetoDtoListagem>();
            CreateMap<ProjetoDtoListagem, ProjetoEntity>();
            CreateMap<ProjetoEntity, ProjetoDtoSimple>();
            CreateMap<ProjetoEntity, ProjetoDtoUpdate>();
            CreateMap<ProjetoDtoUpdate, ProjetoEntity>();
        }
    }
}
