using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Email
{
    public interface IEmailService
    {
        void EnviarEmail(List<Destinatario> destinatario, string assunto, int usuarioId, string username, string codigoAtivacao, string pageTitle, string email = "");
    }
}
