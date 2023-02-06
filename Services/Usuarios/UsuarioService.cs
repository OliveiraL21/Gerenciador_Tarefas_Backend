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
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager , IEmailService emailService) 
        {
           _mapper = mapper;
           _userManager = userManager;
            _roleManager = roleManager;
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

        public Result createUsuario(Usuario usuario)
        {
            IdentityUser<int> user = _mapper.Map<IdentityUser<int>>(usuario);

            var result = _userManager.CreateAsync(user, usuario.Password);

            var role = _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;

            var usuarioRole = _userManager.AddToRoleAsync(user, "admin");

            if (result.Result.Succeeded)
            {
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
    }

}
