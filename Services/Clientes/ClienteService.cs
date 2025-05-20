using AutoMapper;
using Data.Context;
using Domain.Dtos.cliente;
using Domain.Entidades;
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
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        public ClienteService(IRepository<Cliente> clienteRepository, MyContext context,  IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _context = context;
            _mapper = mapper;
        }
        public bool delete(int id)
        {
            if (id != null)
            {
                var result = _clienteRepository.delete(id);
                return result;
            }
            return false;
        }

        public List<Cliente> filtrarClientes(string? razaoSocial, string? cnpj)
        {
            razaoSocial = razaoSocial == "null" ? null : razaoSocial;
            cnpj = cnpj == "null" ? null : cnpj;

            if (!string.IsNullOrEmpty(cnpj))
            {
                cnpj = cnpj.Substring(0, 10) + '/' + cnpj.Substring(11);
            }
            var result = _context.Clientes.Include(c => c.Projetos).AsQueryable();

            if (!string.IsNullOrEmpty(razaoSocial))
            {
                result = result.Where(x => EF.Functions.Like(x.RazaoSocial, $"%{razaoSocial}%"));
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                 result = result.Where(x => EF.Functions.Like(x.Cnpj, $"%{cnpj}%"));
            }

            return result.ToList();
        }

        public Cliente insert(Cliente entity)
        {
            if (entity != null)
            {
                var result = _clienteRepository.insert(entity);
                return result;
            }
            return null;
        }

        public IEnumerable<Cliente> listarClientes()
        {
            return _context.Clientes.Include(x => x.Projetos).ToList().OrderBy(x => x.RazaoSocial);
        }

        public IEnumerable<ClienteListSimple> ListaSimples()
        {
            var result = new List<ClienteListSimple>();
            var clientes = _context.Clientes.ToList();
            clientes.ForEach(cliente =>
            {
                result.Add(_mapper.Map<ClienteListSimple>(cliente));
            });

            return result;
        }

        public Cliente select(int id)
        {
            if (id != null)
            {
                return _clienteRepository.select(id);
            }
            return null;
        }

        public Cliente update(Cliente entity)
        {
            if (entity.Id != null && entity != null)
            {
                var result = _clienteRepository.update(entity);
                return result;
            }
            return null;
        }
    }
}
