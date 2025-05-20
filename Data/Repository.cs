using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<bool> ExistAsync(Guid id)
        {
            return _dbSet.AnyAsync(i => i.Id == id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(x => x.Id == id);
                if (result == null)
                {
                    return false;
                }
                _dbSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                entity.CreateAt = DateTime.UtcNow;
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
                       
            return entity;
            
        }

        public Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = _dbSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (result == null)
                    return null;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<T>> SelectAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            try
            {
                var entityOriginal = await _dbSet.SingleOrDefaultAsync(i => i.Id == id);

                if (entityOriginal == null)
                {
                    return null;
                }

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = entityOriginal.CreateAt;

                // Entry = entrada, que é onde vai o original, SetValues põe o valor do novo item.
                _context.Entry(entityOriginal).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return entity;
        }
    }
}
