using Application.DTO.StatusDTO;
using AutoMapper;
using Domain.Dtos.cliente;
using Domain.Dtos.projeto;
using Domain.Dtos.status;
using Domain.Dtos.tarefas;
using Domain.Dtos.User;
using Domain.Entidades;
using Domain.Models;
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

            CreateMap<StatusEntity, StatusDto>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoCreate>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoCreateResult>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoUpdate>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoUpdateResult>()
                .ReverseMap();


            CreateMap<StatusEntity, StatusDtoListagem>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDto>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoCreate>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoCreateResult>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoUpdate>()
                .ReverseMap();

            CreateMap<TarefaEntity, TarefaDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDto>()
            .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoSimple>()
                .ReverseMap();

            CreateMap<ProjetoEntity, ProjetoDtoListagem>()
                .ReverseMap();

            CreateMap<UsuarioEntity, UserDto>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoCreate>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoCreateResult>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoUpdate>()
               .ReverseMap();


            CreateMap<UsuarioEntity, UserDtoUpdateResult>()
               .ReverseMap();
        }
    }
}
