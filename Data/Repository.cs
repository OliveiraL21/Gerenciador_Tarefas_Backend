using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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


        public bool delete(int id)
        {
            if(id > 0)
            {
                var entity = _dbSet.SingleOrDefault(x =>x.Id == id);
                if(entity != null)
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public T insert(T entity)
        {
            if(entity != null)
            {
                _context.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public T select(int id)
        {
            if(id > 0 ) 
            {
                return _dbSet.SingleOrDefault(x => x.Id == id);
            }
            return null;
        }

        public T update(T entity)
        {
            if(entity != null )
            {
                var origin = _dbSet.SingleOrDefault( x => x.Id == entity.Id);
                if(origin != null)
                {
                    _context.Entry(origin).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return  entity;
                }
            }
            return null;
        }
    }
}
