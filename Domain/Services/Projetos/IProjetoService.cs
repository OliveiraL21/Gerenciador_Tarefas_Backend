using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Projetos
{
    public interface IProjetoService : IRepository<Projeto>
    {
        double CalcularValorTotal(TimeSpan total_horas);
        IEnumerable<Projeto> listaSimples();
        IEnumerable<Projeto> FiltrarProjetos(int? projeto, int? clienteId, int? statusId);
        List<Projeto> GetAll();
    }
}
