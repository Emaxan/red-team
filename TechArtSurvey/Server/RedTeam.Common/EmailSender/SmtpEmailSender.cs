using JetBrains.Annotations;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RedTeam.Common.EmailSender
{
    [UsedImplicitly]
    public class EmailSender : IEmailSender
    {
        private readonly string _from;
        private readonly string _password;


        public EmailSender()
        {
            var emailConfiguration = (NameValueCollection)ConfigurationManager.GetSection("EmailServiceConfig");

            _from = emailConfiguration["UserName"];
            _password = emailConfiguration["Password"];
        }


        public async Task SendMailAsync(string destination, string subject, string body)
        {
            var smtpConfiguration = (NameValueCollection)ConfigurationManager.GetSection("SmtpConfig");

            var client = new SmtpClient(smtpConfiguration["Host"], int.Parse(smtpConfiguration["Port"]))
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(_from, _password),
                EnableSsl = true
            };

            var message = BuildMailMessage(destination, subject, body);

            await client.SendMailAsync(message);
        }

        private MailMessage BuildMailMessage(string destination, string subject, string body)
        {
            var mail = new MailMessage(_from, destination)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true
            };

            return mail;
        }
    }
}