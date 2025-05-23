using Domain.Dtos.projeto;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Projetos
{
    public interface IProjetoService
    {
        Task<ProjetoDto> SelectAsync(Guid id);
        Task<ProjetoDtoCreateResult> InsertAsync(ProjetoDtoCreate projeto);
        Task<ProjetoDtoUpdateResult> UpdateAsync(Guid id, ProjetoDtoUpdate projeto);
        Task<bool> DeleteAsync(Guid id);
        Task<double> CalcularValorTotalAsync(TimeSpan total_horas);
        Task<IEnumerable<ProjetoDtoSimple>> listaSimplesAsync();
        Task<IEnumerable<ProjetoDtoListagem>> FiltrarAsync(Guid? projeto, Guid? clienteId, Guid? statusId);
        Task<IEnumerable<ProjetoDtoListagem>> GetAll();
    }
}
