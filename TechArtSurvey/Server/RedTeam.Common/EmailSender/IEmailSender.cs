using System.Threading.Tasks;

namespace RedTeam.Common.EmailSender
{
    public interface IEmailSender
    {
        Task SendMailAsync(string destination, string subject, string body);
    }
}