﻿using System.Web.Http;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        private readonly IApplicationUserManager _userManager;

  
        public AccountController(IApplicationUserManager userManager)
        {
            _userManager = userManager;
        }


        [Route("signup")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IServiceResponse> Signup(UserDto user)
        {      
            return await _userManager.CreateAsync(user);
        }
    }
}