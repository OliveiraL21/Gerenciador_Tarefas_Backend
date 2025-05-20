using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository <T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(Guid id, T entity);

        Task<T> SelectAsync(Guid id);

        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistAsync(Guid id);

       
    }
}
