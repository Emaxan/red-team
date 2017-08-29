using JetBrains.Annotations;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RedTeam.Common.EmailSender
{
    [UsedImplicitly]
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpClient _client;


        public SmtpEmailSender()
        {
            _client = new SmtpClient();
        }


        public async Task SendMailAsync(string destination, string subject, string body)
        {
            var message = BuildMailMessage(destination, subject, body);
            await _client.SendMailAsync(message);
        }


        private MailMessage BuildMailMessage(string destination, string subject, string body)
        {
            var mail = new MailMessage()
            {
                Subject = subject,
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true,
                To = { new MailAddress(destination) }
            };

            return mail;
        }
    }
}