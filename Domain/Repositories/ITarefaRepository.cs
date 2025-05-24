using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITarefaRepository : IRepository<TarefaEntity>
    {
        Task<string> calcularHorasTotaisAsync(DateTime data);
        Task<IEnumerable<TarefaEntity>> FiltrarAsync(string descricao, string dataInicio, string dataFim, Guid? projetoId);

    }
}
