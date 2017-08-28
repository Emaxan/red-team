using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Responses;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation
{
    [UsedImplicitly]
    public class ResetPasswordService : IResetPasswordService
    {
        private readonly ApplicationUserManager _userManager;


        public ResetPasswordService(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }


        public async Task<IServiceResponse> SendResetPasswordMessageAsync(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null)
            {
                return ServiceResponse.CreateUnsuccessful(ServiceResponseCode.UserNotFoundByEmail);
            }

            var result = await GetPasswordResetTokenAsync(user.Id);
            string passwordResetToken = result.Content;

            return await SendConfirmationEmailAsync(user.Id, passwordResetToken, forgotPasswordDto.CallbackUrl);
        }

        public async Task<IServiceResponse> CheckPasswordResetTokenAsync(ResetPasswordDto resetPasswordDto)
        {
            LoggerContext.Logger.Info("Check password reset token");

            var result = await _userManager.VerifyUserTokenAsync(
                resetPasswordDto.UserId, 
                "ResetPassword", 
                resetPasswordDto.ResetPasswordToken);

            if (result)
            {
                return ServiceResponse.CreateSuccessful();
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCode.ResetPasswordTokenInvalid);
        }

        public async Task<IServiceResponse> ResetUserPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            LoggerContext.Logger.Info("Reset password async");

            var result = await _userManager.ResetPasswordAsync(
                resetPasswordDto.UserId, 
                resetPasswordDto.ResetPasswordToken, 
                resetPasswordDto.NewPassword);

            if (result.Succeeded)
            {
                return ServiceResponse.CreateSuccessful();
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCode.ResetPasswordTokenInvalid);
        }


        private async Task<IServiceResponse<string>> GetPasswordResetTokenAsync(int userId)
        {
            LoggerContext.Logger.Info("Generate password reset token");

            string resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(userId);

            return ServiceResponse.CreateSuccessful(resetPasswordToken);
        }

        private async Task<IServiceResponse> SendConfirmationEmailAsync(int userId, string resetPasswordToken, string callbackUrl)
        {
            LoggerContext.Logger.Info("Send confirmation email");

            await _userManager.SendEmailAsync(
                userId,
                "ITechArt Surveys: reset password",
                $"Please reset your password by using this <a href='{callbackUrl}/{userId}/{resetPasswordToken}'>link</a>"
            );

            return ServiceResponse.CreateSuccessful();
        }
    }
}