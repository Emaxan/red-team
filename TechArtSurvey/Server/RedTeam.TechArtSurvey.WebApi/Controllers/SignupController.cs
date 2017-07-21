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


namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    public class SignupController : ApiController
    {
        private readonly ISignupService _signupService;
        public SignupController(ISignupService signupService)
        {
            _signupService = signupService;
        }

        // POST api/Users
        [HttpPost]
        public async Task<IServiceResponse> AddUser(UserDto user)
        {
            LoggerContext.Logger.Info($"Create User with email = {user.Email}");
            return await _signupService.CreateAsync(user);
        }
    }
}
