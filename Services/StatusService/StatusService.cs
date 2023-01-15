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
    public class StatusService : IRepository<Status>
    {
        private readonly IRepository<Status> _repository;
        private readonly MyContext _context;

        public StatusService(IRepository<Status> repository, MyContext context)
        {
           _repository= repository;
            _context= context;
        }

        public Status insert(Status status)
        {
            var result = _repository.insert(status);
            return result;
        }

        public bool delete(int id)
        {
            var result = _repository.delete(id);
            return result;
        }

        public Status select(int id)
        {
           return _repository.select(id);
        }

        public IEnumerable<Status> listaStatus()
        {
            return _context.Status.ToList();
        }

        public Status update(Status status)
        {
           return _repository.update(status);
        }
    }
}
