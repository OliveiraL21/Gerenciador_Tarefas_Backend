using Data.Context;
using Data.Repository;
using Domain.Dtos.cliente;
using Domain.Entidades;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class ClienteImplementation : BaseRepository<ClienteEntity>, IClienteRepository
    {
        private DbSet<ClienteEntity> _dataSet;
        public ClienteImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ClienteEntity>();
        }

        public async Task<IEnumerable<ClienteEntity>> filtrarClientes(string razaoSocial, string cnpj)
        {
            try
            {
                razaoSocial = razaoSocial == "null" ? null : razaoSocial;
                cnpj = cnpj == "null" ? null : cnpj;

                if (!string.IsNullOrEmpty(cnpj))
                {
                    cnpj = cnpj.Substring(0, 10) + '/' + cnpj.Substring(11);
                }
                var result = _dataSet.Include(c => c.Projetos).AsQueryable();

                if (!string.IsNullOrEmpty(razaoSocial))
                {
                    result = result.Where(x => EF.Functions.Like(x.RazaoSocial, $"%{razaoSocial}%"));
                }

                if (!string.IsNullOrEmpty(cnpj))
                {
                    result = result.Where(x => EF.Functions.Like(x.Cnpj, $"%{cnpj}%"));
                }

                return await result.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteEntity>> GetAll()
        {
            try
            {
                return (await _dataSet.Include(x => x.Projetos).ToListAsync()).OrderBy(x => x.RazaoSocial);
            } catch 
            { 
                throw; 
            }
        }

    }
}
