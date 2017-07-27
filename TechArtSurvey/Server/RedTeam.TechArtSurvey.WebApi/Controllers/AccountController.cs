using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;


using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Web;
using RedTeam.TechArtSurvey.Foundation.Dto.AccountDto;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
   [Authorize]
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("api/account/signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> Signup(UserDto user)
        {
            
            return await _userService.CreateAsync(user);
        }
    }
}
