using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using RedTeam.Common.EmailSender;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Services
{
    [UsedImplicitly]
    public class EmailIdentityMessageService : IIdentityMessageService
    {
        private readonly IEmailSender _emailSender;


        public EmailIdentityMessageService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }


        public Task SendAsync(IdentityMessage message)
        {
            return _emailSender.SendMailAsync(message.Destination, message.Subject, message.Body);
        }
    }
}