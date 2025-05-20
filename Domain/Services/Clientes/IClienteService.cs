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
        List<ClienteEntity> filtrarClientes(string razaoSocial, string cnpj);
        IEnumerable<ClienteEntity> listarClientes();
        IEnumerable<ClienteListSimple> ListaSimples();
    }
}