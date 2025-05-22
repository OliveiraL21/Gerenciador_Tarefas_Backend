using Domain.Dtos.cliente;
using Domain.Entidades;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Clientes
{
    public interface IClienteService
    {
        Task<ClienteDtoCreateResult> InsertAsync(ClienteDtoCreate cliente);
        Task<bool> DeleteAsync(Guid id);
        Task<ClienteDtoUpdateResult> UpdateAsync(Guid id, ClienteDtoUpdate cliente);
        Task<ClienteDto> GetAsync(Guid id);
        Task<IEnumerable<ClienteDto>> FiltrarAsync(string razaoSocial, string cnpj);
        Task<IEnumerable<ClienteDto>> ListarAsync();
        Task<IEnumerable<ClienteDtoSimple>> ListaSimplesAsync();
    }
}