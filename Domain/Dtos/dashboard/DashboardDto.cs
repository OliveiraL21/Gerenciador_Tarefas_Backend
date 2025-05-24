using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.dashboard
{
    public class DashboardDto : BaseEntity
    {
        public int ProjetosAtivos { get; set; }
    }
}
