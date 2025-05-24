using Data.Context;
using Domain.Dtos.dashboard;
using Domain.Services.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DashBoard
{
    public class DashboardService : IDashboardService
    {
        private readonly MyContext _context;

        public DashboardService(MyContext context)
        {
            _context = context;
        }

        public DashboardDto CarregarDadosIniciais()
        {
           var result = new DashboardDto();

            result.ProjetosAtivos = _context.Projetos.Count();

            return result;
        }
    }
}
