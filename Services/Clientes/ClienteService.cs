using Data.Context;
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
        public ClienteService(IRepository<Cliente> clienteRepository, MyContext context)
        {
            _clienteRepository = clienteRepository;
            _context = context;
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

        public List<Cliente> filtrarClientes(string? razaoSocial, string? cnpj, string? email)
        {
            var razao = razaoSocial == "null" ? null : razaoSocial;
            var cnpjCliente = cnpj == "null" ? null : cnpj;
            var emailCliente = email == "null" ? null : email;

            if (!string.IsNullOrEmpty(razao) && string.IsNullOrEmpty(cnpjCliente) && string.IsNullOrEmpty(emailCliente))
            {
                var result = _context.Clientes.Where(x => EF.Functions.Like(x.RazaoSocial, $"%{razao}%")).Include(p => p.Projetos).ToList();
                return result;
            }

            if (string.IsNullOrEmpty(razao) && !string.IsNullOrEmpty(cnpjCliente) && string.IsNullOrEmpty(emailCliente))
            {
                var result = _context.Clientes.Where(x => EF.Functions.Like(x.Cnpj, $"%{cnpjCliente}%")).Include(p => p.Projetos).ToList();
                return result;
            }

            if (string.IsNullOrEmpty(razao) && string.IsNullOrEmpty(cnpjCliente) && !string.IsNullOrEmpty(emailCliente))
            {
                var result = _context.Clientes.Where(x => EF.Functions.Like(x.Email, $"%{emailCliente}%")).Include(p => p.Projetos).ToList();
                return result;
            }
            else
            {
                var result = _context.Clientes.Include(x => x.Projetos).ToList();
                return result;
            }
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
