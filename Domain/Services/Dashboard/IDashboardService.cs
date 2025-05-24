using Domain.Dtos.dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Dashboard
{
    public interface IDashboardService
    {
        DashboardDto CarregarDadosIniciais();
    }
}
