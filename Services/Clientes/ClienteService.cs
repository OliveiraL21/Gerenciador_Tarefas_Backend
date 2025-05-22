using AutoMapper;
using Data.Context;
using Domain.Dtos.cliente;
using Domain.Entidades;
using Domain.Models;
using Domain.Repositories;
using Domain.Repository;
using Domain.Services.Clientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository, MyContext context,  IMapper mapper)
        {
            _repository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id != null)
            {
                var result = await _repository.DeleteAsync(id);
                return result;
            }
            return false;
        }

        public async Task<IEnumerable<ClienteDto>> FiltrarAsync(string? razaoSocial, string? cnpj)
        {
           return _mapper.Map<IEnumerable<ClienteDto>>(await _repository.filtrarClientes(razaoSocial, cnpj));
        }

        public async Task<ClienteDtoCreateResult> InsertAsync(ClienteDtoCreate cliente)
        {
            if (cliente != null)
            {
                var model = _mapper.Map<ClienteModel>(cliente);
                var entity = _mapper.Map<ClienteEntity>(model);
                var result = _mapper.Map<ClienteDtoCreateResult>(await _repository.InsertAsync(entity));
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ClienteDto>> ListarAsync()
        {
            return  _mapper.Map<IEnumerable<ClienteDto>>(await _repository.GetAll());
        }

        public async Task<IEnumerable<ClienteDtoSimple>> ListaSimplesAsync()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ClienteDtoSimple>>(result);
        }

        public async Task<ClienteDto> GetAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return _mapper.Map<ClienteDto>(await _repository.SelectAsync(id));
            }
            return null;
        }

        public async Task<ClienteDtoUpdateResult> UpdateAsync(Guid id, ClienteDtoUpdate cliente)
        {
            if (id != Guid.Empty && cliente != null)
            {
                cliente.Id = id; 
                var model = _mapper.Map<ClienteModel>(cliente);
                var entity = _mapper.Map<ClienteEntity>(model);
                var result = await _repository.UpdateAsync(id, entity);
                return _mapper.Map<ClienteDtoUpdateResult>(result);
            }
            return null;
        }
    }
}
