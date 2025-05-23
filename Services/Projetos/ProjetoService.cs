using AutoMapper;
using Data.Context;
using Domain.Dtos.projeto;
using Domain.Entidades;
using Domain.Models;
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

        public async Task<IEnumerable<ProjetoDtoListagem>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProjetoDtoListagem>>(await _repository.GetAll());
        }

        public async Task<ProjetoDtoCreateResult> InsertAsync(ProjetoDtoCreate projeto)
        {
            var model = _mapper.Map<ProjetoModel>(projeto);
            var entity = _mapper.Map<ProjetoEntity>(model);
            return _mapper.Map<ProjetoDtoCreateResult>(await  _repository.InsertAsync(entity));
        }

        public async Task<IEnumerable<ProjetoDtoSimple>> ListaSimplesAsync()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ProjetoDtoSimple>>(result);
        }

        public async Task<ProjetoDto> SelectAsync(Guid id)
        {
            return _mapper.Map<ProjetoDto>(await _repository.SelectAsync(id));
        }

        public async Task<ProjetoDtoUpdateResult> UpdateAsync(Guid id, ProjetoDtoUpdate projeto)
        {
            var model = _mapper.Map<ProjetoModel>(projeto);
            var entity = _mapper.Map<ProjetoEntity>(model);
            return  _mapper.Map<ProjetoDtoUpdateResult>(await _repository.UpdateAsync(id,entity));
        }
    }
}
