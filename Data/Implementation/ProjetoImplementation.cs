using Data.Context;
using Data.Repository;
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
    public class ProjetoImplementation : BaseRepository<ProjetoEntity>, IProjetoRepository
    {
        private DbSet<ProjetoEntity> _dataSet;
        public ProjetoImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ProjetoEntity>();
        }

        async Task<IEnumerable<ProjetoEntity>> IProjetoRepository.FiltrarAsync(Guid? projeto, Guid? clienteId, Guid? statusId)
        {
            try
            {
                var result = _dataSet.Include(p => p.Cliente).Include(p => p.Status).AsQueryable();

                if (projeto != Guid.Empty)
                {
                    result = result.Where(p => p.Id == projeto);
                }

                if (clienteId != Guid.Empty)
                {
                    result = result.Where(p => p.ClienteId == clienteId);
                }

                if (statusId != Guid.Empty)
                {
                    result = result.Where(p => p.StatusId == statusId);
                }

                return await result.ToListAsync();
            } catch
            {
                throw;
            }
        }

        Task<IEnumerable<ProjetoEntity>> IProjetoRepository.GetAll()
        {
            try
            {

            }
            catch
            {
                throw;
            }
        }

        Task<IEnumerable<ProjetoEntity>> IProjetoRepository.listaSimplesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
