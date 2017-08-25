using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.Logger;
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


        public async Task<IServiceResponse> GetPasswordResetTokenAsync(int userId)
        {
            LoggerContext.Logger.Info("Generate password reset token");

            string resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(userId);

            return ServiceResponse.CreateSuccessful(resetPasswordToken);
        }

        public async Task<IServiceResponse> SendConfirmationEmailAsync(int userId, string resetPasswordToken, string callbackUrl)
        {
            LoggerContext.Logger.Info("Generate password reset token");

            await _userManager.SendEmailAsync(
                userId,
                "ITechArt Surveys: reset password",
                $"Please reset your password by using this <a href='{callbackUrl}/{userId}/{resetPasswordToken}'>link</a>"
            );

            return ServiceResponse.CreateSuccessful(ServiceResponseCode.Ok);
        }

        public async Task<IServiceResponse> CheckPasswordResetTokenAsync(int userId, string resetPasswordToken)
        {
            LoggerContext.Logger.Info("Check password reset token");

            var result = await _userManager.VerifyUserTokenAsync(userId, "ResetPassword", resetPasswordToken);
            if (result)
            {
                return ServiceResponse.CreateSuccessful(ServiceResponseCode.Ok);
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCode.ResetPasswordTokenInvalid);
        }

        public async Task<IServiceResponse> ResetUserPasswordAsync(int userId, string resetPasswordToken, string newPassword)
        {
            LoggerContext.Logger.Info("Reset password async");

            var result = await _userManager.ResetPasswordAsync(userId, resetPasswordToken, newPassword);
            if (result.Succeeded)
            {
                return ServiceResponse.CreateSuccessful(ServiceResponseCode.Ok);
            }

            return ServiceResponse.CreateUnsuccessful(ServiceResponseCode.ResetPasswordTokenInvalid);
        }
    }
}