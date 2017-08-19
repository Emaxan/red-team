using System.Web.Http;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
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
        public async Task<IServiceResponse> Signup(UserDto user)
        {      
            return await _userService.CreateAsync(user);
        }
    }
}