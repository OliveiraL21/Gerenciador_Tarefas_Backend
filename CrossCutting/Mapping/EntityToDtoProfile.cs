using AutoMapper;
using Domain.Dtos.cliente;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<ClienteEntity, ClienteDto>()
                .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoCreate>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoCreateResult>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoUpdate>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoUpdateResult>()
               .ReverseMap();

            CreateMap<ClienteEntity, ClienteDtoSimple>()
               .ReverseMap();
        }
    }
}
