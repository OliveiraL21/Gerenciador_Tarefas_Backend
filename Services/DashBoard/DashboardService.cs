using Data.Context;
using Domain.Entidades;
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

        public DashboardEntity CarregarDadosIniciais()
        {
           var result = new DashboardEntity();

            result.ProjetosAtivos = _context.Projetos.Count();

            return result;
        }
    }
}
