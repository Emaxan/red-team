using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IResetPasswordService
    {
        Task<IServiceResponse> SendResetPasswordMessageAsync(ForgotPasswordDto forgotPasswordDto);
        Task<IServiceResponse> CheckPasswordResetTokenAsync(ResetPasswordDto resetPasswordDto);
        Task<IServiceResponse> ResetUserPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}