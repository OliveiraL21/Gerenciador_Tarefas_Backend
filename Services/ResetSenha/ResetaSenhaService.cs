using Domain.Entidades;
using Domain.Services.ResetaSenha;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ResetSenha
{
    public class ResetaSenhaService : IResetaSenha
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public ResetaSenhaService(SignInManager<IdentityUser<int>>signInManager)
        {
            _signInManager = signInManager;

        }

        private IdentityUser<int> RecuperaUsuarioEmail (string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result SolicitaResetSenha(SolicitaRedefinicaoRequest redefinicaoRequest)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioEmail(redefinicaoRequest.Email);

            var codigo = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser);

            if(codigo != null )
            {
                return Result.Ok().WithSuccess(codigo.Result);
            }
            return Result.Fail("Erro ao gerar o token de redefinição, verifique novamente mais tarde");
        }

        public Result EfetuarResetSenhaUsuario(ResetaSenhaRequest resetSenha)
        {
            IdentityUser<int> identityUser = RecuperaUsuarioEmail(resetSenha.Email);

            var result = _signInManager.UserManager.ResetPasswordAsync(identityUser, resetSenha.Password, resetSenha.Token).Result;

            if(result != null)
            {
                return Result.Ok().WithSuccess("Senha Recuperada com sucesso !");
            }

            return Result.Fail("Erro ao tentar recuperar a senha, por favor tente novamente !");
        }
    }
}
