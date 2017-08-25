using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Services
{
    public class EmailService : IIdentityMessageService
    {
        private readonly string _from;
        private readonly string _password;


        public EmailService(string from, string password)
        {
            _from = from;
            _password = password;
        }


        public Task SendAsync(IdentityMessage message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_from, _password),
                EnableSsl = true
            };

            var mail = BuildMessage(_from, message);

            return client.SendMailAsync(mail);
        }


        private MailMessage BuildMessage(string sender, IdentityMessage message)
        {
            var mail = new MailMessage(sender, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true
            };

            return mail;
        }
    }
}