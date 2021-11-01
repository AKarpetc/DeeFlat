using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System;
using MimeKit.Text;
using System.Collections.Generic;
using System.Linq;

namespace DeeFlat.Email.Services.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(IEnumerable<string> emails, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        private IHostEnvironment _env;

        public EmailService(IHostEnvironment env)
        {
            _env = env;
        }

        public async Task SendEmailAsync(IEnumerable<string> emails, string subject, string body)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "sender@gmail.com"));
            emailMessage.To.AddRange(emails.Select(email => new MailboxAddress("", email)));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                if (_env.IsDevelopment())
                {
                    Console.WriteLine($"Email={string.Join(";", emails)}  Subject={subject}");
                    Console.WriteLine($"Message={body}");
                }

                if (_env.IsProduction())
                {
                    //TODO: Добавить получение данных из конфигурации, проверить вне домена kazzinc.kz
                    await client.ConnectAsync("smtp.yandex.ru", 465, true);//587 465

                    await client.AuthenticateAsync("sender@gmail.com", "password");

                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
