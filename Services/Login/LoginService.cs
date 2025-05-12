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
        private readonly SignInManager<CustomIdentityUser> _signManager;
        private ITokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signManager, ITokenService tokenService)
        {
            _signManager = signManager;
            _tokenService = tokenService;
        }

        public bool UsuarioExiste(string username)
        {
            bool exist = _signManager.UserManager.Users.Any(x => x.UserName == username);

            return exist ? exist : false;
        }

        private CustomIdentityUser RecuperaUsuario(string username)
        {
            var user = _signManager.UserManager.Users.SingleOrDefault(x => x.UserName == username);

            return user;
        }

        public bool VerificaSenha(string username, string senha)
        {
            if(username != "" && senha != "")
            {
                var user = RecuperaUsuario(username);

                if(user != null)
                {
                    PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
                    var isEqual = hasher.VerifyHashedPassword(user, user.PasswordHash, senha);
                    return isEqual.ToString() == "Failed" ? false : true; 
                }
            }
            return false;
        }

        public ResultToken  Login(LoginRequest login)
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
                    tokenResult.Message = "Usuário logado com sucesso!";
                    tokenResult.IsFail = false;
                    tokenResult.Authenticated = true;
                    return tokenResult;

                }

                ResultToken resultReturn = new ResultToken()
                {
                    UsuarioId = 0,
                    Token = "",
                    Message = result.Result.IsNotAllowed ? "Usuário não autorizado, por favor ative o seu usuário pelo link enviado ao e-mail de cadastro" : "Usuário não encontrado",
                    IsFail = true,
                    Authenticated = false
                };

                return resultReturn;

            }
            return null;
        
        }
    }
}
