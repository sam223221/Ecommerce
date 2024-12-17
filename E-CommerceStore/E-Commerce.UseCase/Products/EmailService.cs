using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using E_Commerce.UseCase.PluginInterfaces;
using ECommerce.CoreEntityBusiness;
using E_Commerce.UseCase.Products.Interfaces;
using E_Commerce.UseCase.Products;

namespace E_Commerce.UseCase.Products
{ 
    public class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailService(IConfiguration configuration)
        {
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:Port"]);
            _smtpUser = configuration["EmailSettings:Username"];
            _smtpPassword = configuration["EmailSettings:Password"];
            _fromEmail = configuration["EmailSettings:FromEmail"];
            _fromName = configuration["EmailSettings:FromName"];
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            using var client = new SmtpClient(_smtpServer, _smtpPort)
            {
                Credentials = new NetworkCredential(_smtpUser, _smtpPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_fromEmail, _fromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
    }
}
