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

  
        public AccountController(IUserService userService)
        {
            _userService = userService;
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
            result = await _userService.GetPasswordResetTokenAsync(user.Id);

            string passwordResetToken = result.Content as string;
            result = await _userService.SendConfirmationEmailAsync(user.Id, passwordResetToken, forgotPasswordDto.CallbackUrl);

            return result;
        }

        [Route("check_token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> CheckPasswordResetToken(CheckPasswordResetTokenDto checkPasswordResetTokenDto)
        {
            var result = await _userService.CheckPasswordResetTokenAsync(
                checkPasswordResetTokenDto.UserId,
                checkPasswordResetTokenDto.Token);

            return result;
        }

        [Route("reset_password")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var result = await _userService.ResetUserPasswordAsync(
                resetPasswordDto.UserId,
                resetPasswordDto.ResetPasswordToken,
                resetPasswordDto.NewPassword);

            return result;
        }
    }
}