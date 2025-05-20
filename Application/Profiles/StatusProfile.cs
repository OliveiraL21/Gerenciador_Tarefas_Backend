using Application.DTO.StatusDTO;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<StatusEntity, StatusListagemDTO>();
            CreateMap<StatusListagemDTO, StatusEntity>();
            CreateMap<CreateStatusDto, StatusEntity>();
        }
    }
}
