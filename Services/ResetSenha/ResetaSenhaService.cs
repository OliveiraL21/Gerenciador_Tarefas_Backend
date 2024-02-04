using Domain.Entidades;
using Domain.Services.Email;
using Domain.Services.ResetaSenha;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.ResetSenha
{
    public class ResetaSenhaService : IResetaSenha
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly IEmailService _emailService;

        public ResetaSenhaService(SignInManager<CustomIdentityUser>signInManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _emailService = emailService;

        }

        private CustomIdentityUser RecuperaUsuarioEmail (string email)
        {
            return _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public Result SolicitaResetSenha(SolicitaRedefinicaoRequest redefinicaoRequest)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioEmail(redefinicaoRequest.Email);

            var codigo = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;

            if(codigo != null )
            {
                var destinatarios = new List<Destinatario>()
                {
                   new Destinatario () { Email = redefinicaoRequest.Email, Nome = redefinicaoRequest.Email },
                };

                var encodedUrl = HttpUtility.UrlEncode(codigo);
                _emailService.EnviarEmail(destinatarios, "Solicitar Nova Senha", identityUser.Id, identityUser.UserName, encodedUrl, "Recuperar senha", identityUser.Email);

                return Result.Ok().WithSuccess(codigo);
            }
            return Result.Fail("Erro ao gerar o token de redefinição, verifique novamente mais tarde");
        }

        public Result EfetuarResetSenhaUsuario(ResetaSenhaRequest resetSenha)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioEmail(resetSenha.Email);

            var result = _signInManager.UserManager.ResetPasswordAsync(identityUser, resetSenha.Token, resetSenha.Password).Result;

            if(result != null)
            {
                return Result.Ok().WithSuccess("Senha Recuperada com sucesso !");
            }

            return Result.Fail("Erro ao tentar recuperar a senha, por favor tente novamente !");
        }
    }
}
