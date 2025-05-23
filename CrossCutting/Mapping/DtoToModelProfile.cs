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

            CreateMap<TarefaModel, TarefaDto>()
               .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoCreate>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoCreateResult>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoUpdate>()
                .ReverseMap();

            CreateMap<TarefaModel, TarefaDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDto>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoCreate>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoCreateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoUpdateResult>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoUpdate>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoSimple>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoDtoListagem>()
                .ReverseMap();


            CreateMap<UserModel, UserDto>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoCreate>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoCreateResult>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoUpdate>()
               .ReverseMap();


            CreateMap<UserModel, UserDtoUpdateResult>()
               .ReverseMap();
        }
    }
}
