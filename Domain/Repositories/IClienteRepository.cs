using Domain.Dtos.cliente;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        Task<IEnumerable<ClienteEntity>> GetAll();
        Task<IEnumerable<ClienteEntity>> filtrarClientes(string? razaoSocial, string? cnpj);
    }
}
