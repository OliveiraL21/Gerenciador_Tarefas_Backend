using Data.Context;
using Domain.Entidades;
using Domain.Repository;
using Domain.Services.Projetos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Projetos
{
    public class ProjetoService : IProjetoService
    {
        private readonly IRepository<ProjetoEntity> _repository;
        private readonly MyContext _context;
        public ProjetoService(IRepository<ProjetoEntity> repository, MyContext context)
        {
            _repository = repository;
            _context = context;
        }
        public double CalcularValorTotal(TimeSpan total_horas)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            var result = _repository.delete(id);
            return result;
        }

        public IEnumerable<ProjetoEntity> FiltrarProjetos(int? projeto, int? clienteId, int? statusId)
        {
            var projetoId = projeto == null || projeto == 0 ? null : projeto;
            var cliente = clienteId == null || clienteId == 0 ? null : clienteId;
            var status = statusId == null || statusId == 0 ? null : statusId;

            if (projetoId != null && cliente == null && status == null)
            {
                var projetos = _context.Projetos.Where(x => x.Id == projetoId).Include(s => s.Status).Include(c => c.Cliente).ToList();
                return projetos;
            }

            if (projetoId == null && cliente != null && status == null)
            {
                var projetos = _context.Projetos.Where(x => x.ClienteId == cliente).Include(s => s.Status).Include(c => c.Cliente).ToList();
                return projetos;
            }

            if (projetoId == null && cliente == null && status != null)
            {
                var projetos = _context.Projetos.Where(x => x.StatusId == status).Include(s => s.Status).Include(c => c.Cliente).ToList();
                return projetos;
            }
            else
            {
                var projetos = _context.Projetos.Include(x => x.Status).Include(c => c.Cliente).ToList();
                return projetos;
            }
        }

        public List<ProjetoEntity> GetAll()
        {

            var projetos = _context.Projetos.Include(x => x.Status).Include(c => c.Cliente).ToList();
            return projetos;
        }

        public ProjetoEntity insert(ProjetoEntity entity)
        {
            return entity != null ? _repository.insert(entity) : null;
        }

        public IEnumerable<ProjetoEntity> listaSimples()
        {
            var result = _context.Projetos.ToList();
            return result;
        }

        public ProjetoEntity select(int id)
        {
            return id != 0 ? _repository.select(id) : null;
        }

        public ProjetoEntity update(ProjetoEntity entity)
        {
            return  entity != null ? _repository.update(entity) : null;
        }
    }
}
