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
        private readonly SignInManager<IdentityUser<int>> _signManager;
        private ITokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signManager, ITokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public ResultToken Login(LoginRequest login)
        {
            if(login != null)
            {
                
                var result = _signManager.PasswordSignInAsync(login.Username, login.Password, false, false);
                if (result.Result.Succeeded)
                {
                    var identityUser = _signManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == login.Username.ToUpper());
                    var role = _signManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault();
                    Token token = _tokenService.gerarToken(identityUser,role );

                    ResultToken tokenResult = new ResultToken();

                    tokenResult.Token = token.Value;
                    tokenResult.UsuarioId = identityUser.Id;

                    return tokenResult;

                }
                   
            }
            return null;
        }

        public Result Logout(LoginRequest login)
        {
            throw new NotImplementedException();
        }
    }
}
