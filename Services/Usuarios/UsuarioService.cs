using Data.Context;
using Domain.Entidades;
using Domain.Services.Usuarios;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly MyContext _context;
        public UsuarioService(MyContext context) 
        {
            _context= context;
        }

        public Result createUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
