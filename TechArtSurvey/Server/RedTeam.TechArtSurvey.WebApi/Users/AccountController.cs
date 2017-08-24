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


        // POST api/account/signup
        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse<UserDto>> Signup(UserDto user)
        {      
            return await _userService.CreateAsync(user);
        }
    }
}