using AutoMapper;
using Domain.Entidades;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<ClienteModel, ClienteEntity>()
                .ReverseMap();

            CreateMap<StatusModel, StatusEntity>() 
                .ReverseMap();

            CreateMap<TarefaModel, TarefaEntity>()
                .ReverseMap();

            CreateMap<ProjetoModel, ProjetoEntity>()
                .ReverseMap();

            CreateMap<UserModel, UsuarioEntity>()
                .ReverseMap();
        }
    }
}
