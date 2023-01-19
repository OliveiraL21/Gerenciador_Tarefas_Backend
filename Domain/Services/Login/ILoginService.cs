using Domain.Entidades;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public interface ILoginService
    {
        public Result Login(LoginRequest login);
        public Result Logout(LoginRequest login);
    }
}
