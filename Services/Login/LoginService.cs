using Domain.Entidades;
using Domain.Services.Login;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Login
{
    public class LoginService : ILoginService
    {
        // declarando gerenciador de login
        private SignInManager<IdentityUser<int>> _signManager;

        public LoginService(SignInManager<IdentityUser<int>> signManager)
        {
            _signManager = signManager;
        }

        public Result Login(LoginRequest login)
        {
            if(login != null)
            {
                var result = _signManager.PasswordSignInAsync(login.Username, login.Password, false, false);
                if (result.Result.Succeeded)
                    return Result.Ok();
            }
            return Result.Fail("Erro ao tentar realizer o login, tente novamente mais tarde");
        }

        public Result Logout(LoginRequest login)
        {
            throw new NotImplementedException();
        }
    }
}
