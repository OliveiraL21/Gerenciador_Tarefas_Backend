using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public interface ILogoutService
    {
        Result Deslogar();
    }
}
