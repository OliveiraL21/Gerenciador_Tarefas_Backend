using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Projetos
{
    public interface IProjetoService : IRepository<ProjetoEntity>
    {
        double CalcularValorTotal(TimeSpan total_horas);
        IEnumerable<ProjetoEntity> listaSimples();
        IEnumerable<ProjetoEntity> FiltrarProjetos(int? projeto, int? clienteId, int? statusId);
        List<ProjetoEntity> GetAll();
    }
}
