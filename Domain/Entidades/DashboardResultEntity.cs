using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class DashboardResultEntity
    {
        public int Segunda { get; set; } = 0;
        public int Terca { get; set; } = 0;
        public int Quarta { get; set; } = 0;
        public int Quinta { get; set; } = 0;
        public int Sexta {get; set;} = 0;
        public int Sabado {get; set;} = 0;
        public int Domingo {get; set;} = 0;
        public double TotalHoras { get; set; } = 0;
    }

 
}
