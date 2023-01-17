using AutoMapper;
using Data.Context;
using Domain.Entidades;
using Domain.Services.Usuarios;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly IMapper _mapper;
        public UsuarioService(IMapper mapper, UserManager<IdentityUser<int>> userManager) 
        {
           _mapper = mapper;
           _userManager = userManager;
        }

        public Result createUsuario(Usuario usuario)
        {
            IdentityUser<int> user = _mapper.Map<IdentityUser<int>>(usuario);
            var result = _userManager.CreateAsync(user, usuario.Password);
            if (result.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail($"Erro ao tentar cadastrar o usuário");
        }
    }
}
