using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ECommerce.Workers
{
    public class EmailSender : IEmailSender
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public bool EnableSSL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public EmailSender()
        {
            Port = 587;
            Host = "smtp.gmail.com";
            EnableSSL = true;
            UserName = "username@gmail.com";
            Password = "password";
            From = "username@gmail.com";
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient client = new SmtpClient
            {
                Port = Port,
                Host = Host,
                EnableSsl = EnableSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(UserName,Password)
            };
            return client.SendMailAsync(From, email, subject, htmlMessage);
        }
    }
}
