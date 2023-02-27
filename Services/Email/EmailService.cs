using Domain.Entidades;
using Domain.Services.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Email
{
    public class EmailService : IEmailService
    {
        private string host = "smtp.gmail.com";
        private int port = 465;
        private string From = "gerenciadortarefas.dias@gmail.com";
        private string Password = "nkdpgxsiqiyxdzwo";


        public void EnviarEmail(List<Destinatario> destinatario, string assunto, int usuarioId, string codigoAtivacao)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, codigoAtivacao);

            var mensagemEmail = criarCorpoEmail(mensagem);

            Enviar(mensagemEmail);
        }

        private void Enviar(MimeMessage mensagemEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(host, port , true);
                   
                    client.Authenticate(From, Password);
                    client.Send(mensagemEmail);
                }
                catch 
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage criarCorpoEmail(Mensagem mensagem)
        {
            //criando a verdadeira mensagem de e-mail que vai ser enviada
            var mensagemEmail = new MimeMessage();

            mensagemEmail.From.Add(new MailboxAddress("Gerenciador de Tarefas", From));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto.ToString();

            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            

            return mensagemEmail;
        }
    }
}
