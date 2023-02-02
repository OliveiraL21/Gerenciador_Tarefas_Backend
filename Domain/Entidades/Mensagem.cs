using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Mensagem
    {
        //lista de destinatarios do mailkit sendo o mailboxadrees
        public List<MailboxAddress> Destinatario { get; set; }

        public string Assunto { get; set; }

        public string Conteudo { get; set; }

        public Mensagem(IEnumerable<Destinatario> destinatarios, string assunto, int usuarioId, string codigoAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatarios.Select(d => new MailboxAddress(d.Nome, d.Email)));
            Assunto = assunto;
            Conteudo = $"https://localhost:44336/ativa?usuarioId={usuarioId}&codigoAtivacao={codigoAtivacao}";
        }
    }
}
