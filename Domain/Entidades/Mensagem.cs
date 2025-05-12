using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Domain.Entidades
{
    public class Mensagem
    {
        //lista de destinatarios do mailkit sendo o mailboxadrees
        public List<MailboxAddress> Destinatario { get; set; }

        public string Assunto { get; set; }

        public string Conteudo { get; set; }

        public string ConteudoResetSenha { get; set; }

        public string PageTitle { get; set; }

        public Mensagem(IEnumerable<Destinatario> destinatarios, string assunto, int usuarioId, string username, string codigoAtivacao, string pageTitle, string email = "")
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatarios.Select(d => new MailboxAddress(d.Nome, d.Email)));
            Assunto = assunto;
            PageTitle = pageTitle;
            Conteudo = $"<!DOCTYPE html>\r\n<html lang=\"pt-Br\" style=\"margin: 0; padding:0\">\r\n\r\n<head>\r\n\t<meta charset=\"UTF-8\">\r\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\t<title>{pageTitle}</title>\r\n\t<style>\r\n\t\t* {{\r\n\t\t\tmargin: 0;\r\n\t\t\tpadding: 0;\r\n\t\t}}\r\n\t</style>\r\n</head>\r\n\r\n<body>\r\n\t<main>\r\n\t\t<div\r\n\t\t\tstyle=\"height: 80px; width: 100%; background-color: #4b5563; display: flex; align-items: center; justify-content: center;\">\r\n\t\t\t<h1 style=\"color: #fff; text-align:center\">Gerenciador de tarefas Dias</h1>\r\n\t\t</div>\r\n\t\t<div style=\"padding: 20px; margin-left: 10px;\">\r\n\t\t\t<h2 style=\"margin:20px 0;\">{pageTitle}</h2>\r\n\t\t\t<p style=\"margin:20px 0;\">Olá {username},</p>\r\n\t\t\t<p>Estamos muito felizes por querer utilizar nosso aplicativo, porém para que possa acessar nosso sistema você\r\n\t\t\t\tprecisa ativar a sua conta.</p>\r\n\t\t\t<p>Clique no botão abaixo para ativar a conta </p>\r\n\t\t\t<a style=\" cursor: pointer \" href=https://localhost:44336/ativa?usuarioId={usuarioId}&codigoAtivacao={codigoAtivacao}>\r\n\t\t\t\t<button\r\n\t\t\t\t\tstyle=\"background-color: #4b5563; cursor: pointer; color: #fff; border-radius: 10px; border: none; padding: 10px; margin-top:40px; width: 120px;\">Clique\r\n\t\t\t\t\tAqui</button>\r\n\t\t\t</a>\r\n\r\n\t\t\t<p style=\"margin-top: 40px\">Se clicar no botão parece não funcionar, você pode copiar e colar o seguinte\r\n\t\t\t\tlink em seu navegador.</p>\r\n\t\t\t<p>https://localhost:44336/ativa?usuarioId={usuarioId}&codigoAtivacao={codigoAtivacao}</p>\r\n\t\t</div>\r\n\t</main>\r\n</body>\r\n\r\n</html>\r\n";
            ConteudoResetSenha = $"<!DOCTYPE html>\r\n<html lang=\"pt-Br\" style=\"margin: 0; padding:0\">\r\n\r\n<head>\r\n\t<meta charset=\"UTF-8\">\r\n\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\t<title>{pageTitle}</title>\r\n\t<style>\r\n\t\t* {{\r\n\t\t\tmargin: 0;\r\n\t\t\tpadding: 0;\r\n\t\t}}\r\n\t</style>\r\n</head>\r\n\r\n<body>\r\n\t<main>\r\n\t\t<div\r\n\t\t\tstyle=\"height: 80px; width: 100%; background-color: #4b5563; display: flex; align-items: center; justify-content: center;\">\r\n\t\t\t<h1 style=\"color: #fff\">Gerenciador de tarefas Dias</h1>\r\n\t\t</div>\r\n\t\t<div style=\"padding: 20px; margin-left: 10px;\">\r\n\t\t\t<h2 style=\"margin:20px 0;\">{pageTitle}</h2>\r\n\t\t\t<p style=\"margin:20px 0;\">Olá {username},</p>\r\n\t\t\t<p>Recebemos uma solicitação para a alteração de sua senha. <br>\r\n\t\t\t\tClique no botão abaixo para mudar sua senha! </p>\r\n\t\t\t<a href=http://localhost:4200/redefinirSenha/{usuarioId}/{email}/{codigoAtivacao}>\r\n\t\t\t\t<button\r\n\t\t\t\t\tstyle=\"background-color: #4b5563; color: #fff; border-radius: 10px; border: none; padding: 10px; cursor: pointer; margin-top:40px; width: 120px;\">Clique\r\n\t\t\t\t\tAqui</button>\r\n\t\t\t</a>\r\n\r\n\t\t\t<p style=\"margin-top: 40px\">Se clicar no botão parece não funcionar, você pode copiar e colar o seguinte\r\n\t\t\t\tlink em seu navegador.</p>\r\n\t\t\t<p>http://localhost:4200/redefinirSenha/{usuarioId}/{email}/{codigoAtivacao}</p>\r\n\t\t</div>\r\n\t</main>\r\n</body>\r\n\r\n</html>\r\n";
        }
    }
}
