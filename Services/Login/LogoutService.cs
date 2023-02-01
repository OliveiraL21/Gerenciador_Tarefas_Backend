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
    public class LogoutService : ILogoutService
    {
        private SignInManager<IdentityUser<int>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<int>>signInManager)
        {
            _signinManager = signInManager;
        }

        public Result Deslogar()
        {
            var resultIdentity = _signinManager.SignOutAsync();
            if (resultIdentity.IsCompletedSuccessfully)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao efetuar o Logout");

        }
    }
}
