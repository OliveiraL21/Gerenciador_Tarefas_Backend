using Application.DTO.Tarefas.Create;
using Application.DTO.Tarefas.Create.ProjetoDTO;
using Application.DTO.Tarefas.Listagem;
using Application.DTO.Tarefas.Update;
using AutoMapper;
using Domain.Entidades;

namespace Application.Profiles
{
    public class TarefaProfile: Profile
    {
        public TarefaProfile()
        {
            CreateMap<CreateTarefaDTO, TarefaEntity>();
            CreateMap<ProjetoCreateDto, ProjetoEntity>();
            CreateMap<UpdateTarefaDTO, TarefaEntity>();
            CreateMap<TarefaListagemDTO, TarefaEntity>();
            CreateMap<TarefaEntity, TarefaListagemDTO>();
        }
    }
}
