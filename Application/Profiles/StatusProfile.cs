using Application.DTO.StatusDTO;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusListagemDTO>();
            CreateMap<StatusListagemDTO, Status>();
            CreateMap<CreateStatusDto, Status>();
        }
    }
}
