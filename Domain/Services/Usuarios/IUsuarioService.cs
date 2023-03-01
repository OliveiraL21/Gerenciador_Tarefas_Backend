using Domain.Entidades;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Usuarios
{
    public interface IUsuarioService
    {
        Result ativaUsuario(AtivaRequest request);
        Result createUsuario(Usuario usuario);
        Result update(Usuario usuario);
        Usuario detaillsUsuario(int id);
        Result updateProfileImage(string imageUrl, int id);
    }
}
