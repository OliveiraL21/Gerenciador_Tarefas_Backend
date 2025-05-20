using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatusService
{
    public class StatusService : IRepository<StatusEntity>
    {
        private readonly IRepository<StatusEntity> _repository;
        private readonly MyContext _context;

        public StatusService(IRepository<StatusEntity> repository, MyContext context)
        {
           _repository= repository;
            _context= context;
        }

        public StatusEntity insert(StatusEntity status)
        {
            var result = _repository.insert(status);
            return result;
        }

        public bool delete(int id)
        {
            var result = _repository.delete(id);
            return result;
        }

        public StatusEntity select(int id)
        {
           return _repository.select(id);
        }

        public IEnumerable<StatusEntity> listaStatus()
        {
            return _context.Status.ToList();
        }

        public StatusEntity update(StatusEntity status)
        {
           return _repository.update(status);
        }
    }
}
