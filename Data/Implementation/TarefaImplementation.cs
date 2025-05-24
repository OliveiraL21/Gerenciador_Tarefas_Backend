using Data.Context;
using Data.Repository;
using Domain.Entidades;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class TarefaImplementation : BaseRepository<TarefaEntity>, ITarefaRepository
    {
        private DbSet<TarefaEntity> _dataSet;
        public TarefaImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<TarefaEntity>();
        }

        public Task<string> calcularHorasTotaisAsync(DateTime data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TarefaEntity>> FiltrarAsync(string descricao, string dataInicio, string dataFim, Guid? projetoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TarefaEntity>> GetAllAsync()
        {
            try
            {
                return await _dataSet.Include(x => x.Projeto).Include(x => x.Status).ToListAsync();
            } catch
            {
                throw;
            }
        }
    }
}
