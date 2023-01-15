using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Tarefas
{
    public interface ITarefaService : IRepository<Tarefa>
    {
        List<Tarefa> filtrarTarefas(string descricao, string dataInicio, string dataFim, int? projetoId);
        string calcularHorasTotais(DateTime data);
        IEnumerable<Tarefa> listaTarefas();
    }
}
