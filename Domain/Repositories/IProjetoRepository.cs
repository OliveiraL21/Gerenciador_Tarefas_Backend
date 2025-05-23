using Domain.Dtos.projeto;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProjetoRepository :IRepository<ProjetoEntity>
    {
        Task<IEnumerable<ProjetoEntity>> FiltrarAsync(Guid? projeto, Guid? clienteId, Guid? statusId);
        Task<IEnumerable<ProjetoEntity>> GetAll();
    }
}
