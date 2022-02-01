using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskScheduler.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _config;
        public EmailSender(EmailConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(Message message)
        {
            var createdMessage = CreateMessage(message);
            await SendMessageAsync(createdMessage);
        }



        private MimeMessage CreateMessage(Message message)
        {
            var mess = new MimeMessage();
            mess.From.Add(new MailboxAddress(_config.From));
            mess.To.AddRange(message.To);
            mess.Subject = message.Title;
            mess.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };
            //var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<p>Hello click the link bellow to get a copy of your invoice{0}</p>", message.Content) };
            return mess;
        }


        private async Task SendMessageAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH");
                    await client.AuthenticateAsync(_config.Username, _config.Password);
                    await client.SendAsync(message);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
