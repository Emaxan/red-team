using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IResetPasswordService
    {
        Task<IServiceResponse> GetPasswordResetTokenAsync(int userId);
        Task<IServiceResponse> SendConfirmationEmailAsync(int userId, string resetPasswordToken, string callbackUrl);
        Task<IServiceResponse> CheckPasswordResetTokenAsync(int userId, string resetPasswordToken);
        Task<IServiceResponse> ResetUserPasswordAsync(int userId, string resetPasswordToken, string newPassword);
    }
}