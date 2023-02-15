using AutoMapper;
using Data.Context;
using Domain.Entidades;
using Domain.Services.Email;
using Domain.Services.Usuarios;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
       
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, IEmailService emailService) 
        {
           _mapper = mapper;
           _userManager = userManager;
           _emailService = emailService;
        }

        public Result ativaUsuario(AtivaRequest request)
        {
            // RECUPERAR O USUARIO PARA A ATIVAÇÃO
            var user = _userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);

            //ATIVANDO O USUÁRIO
            var identityResult = _userManager.ConfirmEmailAsync(user, request.CodigoAtivacao).Result;

            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao tentar ativar a conta do usuário");
        }

        public  Result createUsuario(Usuario usuario)
        {
            IdentityUser<int> user = _mapper.Map<IdentityUser<int>>(usuario);

            Task<IdentityResult> result = _userManager.CreateAsync(user, usuario.Password);
            

            if (result.Result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "regular");

                var code = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                var destinatario = new List<Destinatario>
                {
                    new Destinatario { Nome = usuario.Username, Email = usuario.Email }
                };

                var encodeCode = HttpUtility.UrlEncode(code);

                //ENVIAR EMAIL
                _emailService.EnviarEmail(destinatario, "Código de ativação", user.Id, encodeCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail($"Erro ao tentar cadastrar o usuário");
        }

        public Usuario detaillsUsuario(int id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == id);

            var result = _mapper.Map<Usuario>(user);

            return result;
        }

        public Result update(Usuario usuario)
        {
            IdentityUser<int> user = _mapper.Map<IdentityUser<int>>(usuario);

            var result = _userManager.UpdateAsync(user);

            if (result.Result.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Erro ao tentar atualizar o usuário");
        }
    }

}
