using Application.DTO.StatusDTO;
using AutoMapper;
using Domain.Dtos.cliente;
using Domain.Dtos.status;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<ClienteModel, ClienteDto>()
                .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoCreate>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoCreateResult>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoUpdate>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoUpdateResult>()
               .ReverseMap();

            CreateMap<ClienteModel, ClienteDtoSimple>()
               .ReverseMap();

            CreateMap<StatusModel, StatusDto>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoCreate>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoCreateResult>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoUpdate>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoUpdateResult>()
                .ReverseMap();


            CreateMap<StatusModel, StatusDtoListagem>()
                .ReverseMap();
        }
    }
}
