using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Users
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IResetPasswordService _resetPasswordService;

  
        public AccountController(IUserService userService, IResetPasswordService resetPasswordService)
        {
            _userService = userService;
            _resetPasswordService = resetPasswordService;
        }


        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse<UserDto>> Signup(UserDto user)
        {      
            return await _userService.CreateAsync(user);
        }

        [Route("forgot_password")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var result = await _userService.GetByEmailAsync(forgotPasswordDto.Email);
            if (result.Code != ServiceResponseCode.Ok)
            {
                return result;
            }

            var user = result.Content as EditUserDto;
            result = await _resetPasswordService.GetPasswordResetTokenAsync(user.Id);

            string passwordResetToken = result.Content as string;
            result = await _resetPasswordService.SendConfirmationEmailAsync(user.Id, passwordResetToken, forgotPasswordDto.CallbackUrl);

            return result;
        }

        [Route("check_token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> CheckPasswordResetToken(ResetPasswordDto resetPasswordDto)
        {
            return await _resetPasswordService.CheckPasswordResetTokenAsync(
                resetPasswordDto.UserId,
                resetPasswordDto.ResetPasswordToken);
        }

        [Route("reset_password")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            return await _resetPasswordService.ResetUserPasswordAsync(
                resetPasswordDto.UserId,
                resetPasswordDto.ResetPasswordToken,
                resetPasswordDto.NewPassword);
        }
    }
}