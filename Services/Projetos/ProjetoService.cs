using AutoMapper;
using Data.Context;
using Domain.Dtos.projeto;
using Domain.Entidades;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Projetos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Projetos
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _repository;
        private readonly IMapper _mapper;
        public ProjetoService(IProjetoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public Task<double> CalcularValorTotalAsync(TimeSpan total_horas)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProjetoDtoListagem>> FiltrarAsync(Guid? projeto, Guid? clienteId, Guid? statusId)
        {
            return _mapper.Map<IEnumerable<ProjetoDtoListagem>>(await _repository.FiltrarAsync(projeto, clienteId, statusId));
        }

        public List<ProjetoEntity> GetAll()
        {

            var projetos = _context.Projetos.Include(x => x.Status).Include(c => c.Cliente).ToList();
            return projetos;
        }

        public ProjetoEntity insert(ProjetoEntity entity)
        {
            return entity != null ? _repository.insert(entity) : null;
        }

        public IEnumerable<ProjetoEntity> listaSimples()
        {
            var result = _context.Projetos.ToList();
            return result;
        }

        public ProjetoEntity select(int id)
        {
            return id != 0 ? _repository.select(id) : null;
        }

        public ProjetoEntity update(ProjetoEntity entity)
        {
            return  entity != null ? _repository.update(entity) : null;
        }
    }
}
