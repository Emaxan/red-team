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


        // POST api/account/signup
        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse<ReadUserDto>> Signup(EditUserDto user)
        {      
            return await _userService.CreateAsync(user);
        }

        [Route("forgot_password")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            return await _resetPasswordService.SendResetPasswordMessageAsync(forgotPasswordDto);
        }

        [Route("check_token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse<bool>> CheckPasswordResetToken(ResetPasswordDto resetPasswordDto)
        {
            return await _resetPasswordService.CheckPasswordResetTokenAsync(resetPasswordDto);
        }

        [Route("reset_password")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            return await _resetPasswordService.ResetUserPasswordAsync(resetPasswordDto);
        }
    }
}