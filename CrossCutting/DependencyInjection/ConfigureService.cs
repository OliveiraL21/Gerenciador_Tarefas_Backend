using Domain.Services.Clientes;
using Domain.Services.Dashboard;
using Domain.Services.Projetos;
using Domain.Services.Tarefas;
using Microsoft.Extensions.DependencyInjection;
using Services.Clientes;
using Services.DashBoard;
using Services.Projetos;
using Services.StatusService;
using Services.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IClienteService, ClienteService>();
            serviceCollection.AddTransient<IProjetoService, ProjetoService>();
            serviceCollection.AddTransient<StatusService, StatusService>();
            serviceCollection.AddTransient<ITarefaService, TarefaService>();
            serviceCollection.AddTransient<IDashboardService, DashboardService>();
        }
    }
}
