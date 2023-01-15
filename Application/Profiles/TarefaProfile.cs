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
            CreateMap<CreateTarefaDTO, Tarefa>();
            CreateMap<ProjetoCreateDto, Projeto>();
            CreateMap<UpdateTarefaDTO, Tarefa>();
            CreateMap<TarefaListagemDTO, Tarefa>();
            CreateMap<Tarefa, TarefaListagemDTO>();
        }
    }
}
