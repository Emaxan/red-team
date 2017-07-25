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
   // [Filters.Authorization()]
   [Authorize]
    public class AccountController : ApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("api/account/signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> Signup(UserDto user)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                LoggerContext.Logger.Info($"Trying to sign up when isAuthenticated");
            }
            else
            {
                LoggerContext.Logger.Info($"Create User with email = {user.Email}");
            }
            return await _accountService.SingupAsync(user);
        }

        
        [Route("api/account/logout")]
        [HttpGet]
        public async Task<IServiceResponse> Logout()
        {
            LoggerContext.Logger.Info($"Logging out");
            return await _accountService.LogOut(HttpContext.Current);
        }
    }
}
