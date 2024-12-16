using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace E_Commerce.UseCase.Products
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.sendgrid.net";
        private readonly int _smtpPort = 465; // SSL connection port
        private readonly string _username = "apikey";
        private readonly string _password = "SG.gyo_L8BaQaatFGmnqIMg1g.EymxOAqFpp1TJCrExFXqUEwp4d7I_kSsHLCzvTInfI"; // Replace securely

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your E-Commerce App", "avichalsood2@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_username, _password);
                await client.SendAsync(message);
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
