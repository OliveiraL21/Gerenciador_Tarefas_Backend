using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Domain.Services.Tarefas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tarefas
{
    public class TarefaService : ITarefaService
    {
        private readonly MyContext _context;
        private readonly IRepository<Tarefa> _tarefaRepository;
        private readonly IRepository<Status> _statusRepository;
        public TarefaService(MyContext context, IRepository<Tarefa> tarefaRepository, IRepository<Status> statusRepository)
        {
            _context= context;
            _tarefaRepository = tarefaRepository;
            _statusRepository = statusRepository;
        }
        public string calcularHorasTotais(DateTime data)
        {
            try
            {
                var tarefas = _context.Tarefas.Where(x => x.Data == data).ToList();
                if (tarefas.Any())
                {
                    var duracao = new TimeSpan();

                    foreach (var tarefa in tarefas)
                    {
                        var hora = Convert.ToDateTime(tarefa.Duracao).TimeOfDay;
                        duracao += hora;
                    }
                    return duracao.ToString();
                }
                return "";
            }
            catch
            {
                throw;
            }
        }

        public bool delete(int id)
        {
            if (id != 0)
            {
                return _tarefaRepository.delete(id);
            }
            return false;
        }

        
        public List<Tarefa> filtrarTarefas(string? descricao, string? dataInicio, string? dataFim, int? projetoId)
        {
            try
            {
                var dataInicial = dataInicio == "null" ? null : dataInicio;
                var dataFinal = dataFim == "null" ? null : dataFim;
                var Descricao = descricao == "null" ? null : descricao;

                if (!string.IsNullOrEmpty(Descricao) && dataInicial == null && dataFinal == null && projetoId == 0)
                {
                    var result = _context.Tarefas.Where(x => x.Descricao.Equals(descricao)).Include(s => s.Status).Include(p => p.Projeto).ToList();
                    return result;
                }

                if (string.IsNullOrEmpty(Descricao) && dataInicial != null && dataFinal != null && projetoId == 0)
                {
                    var result = _context.Tarefas.Where(t => t.Data >= Convert.ToDateTime(dataInicial) && t.Data <= Convert.ToDateTime(dataFinal)).Include(s => s.Status).Include(p => p.Projeto).ToList();
                    return result;
                }

                if (string.IsNullOrEmpty(Descricao) && dataInicial == null && dataFinal == null && projetoId != 0)
                {
                    var result = _context.Tarefas.Where(x => x.ProjetoId == projetoId && x.ProjetoId != null).Include(s => s.Status).Include(x => x.Projeto).ToList();


                    return result;
                }
                else
                {
                    var result = _context.Tarefas.Include(t => t.Status).Include(p => p.Projeto).ThenInclude(c => c.Cliente).ToList();
                }
                return _context.Tarefas.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Tarefa insert(Tarefa entity)
        {
            if (entity != null)
            {
                entity.Status = null;
                return _tarefaRepository.insert(entity);
            }
            return null;
        }

        public IEnumerable<Tarefa> listaTarefas()
        {
            var result = _context.Tarefas.Include(x => x.Projeto).Include(s => s.Status).ToList();
            return result;
        }

        public Tarefa select(int id)
        {
            var tarefa = _tarefaRepository.select(id);
            var status = _statusRepository.select(tarefa.StatusId);
            var result = tarefa;
            result.Status = status;
            return result;
        }

        public Tarefa update(Tarefa entity)
        {
            return _tarefaRepository.update(entity);
        }
    }
}
