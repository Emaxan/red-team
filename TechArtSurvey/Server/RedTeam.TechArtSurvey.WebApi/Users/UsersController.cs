using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Users
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        // PUT api/Users/5
        [Route("")]
        [HttpPut]
        public async Task<IServiceResponse> EditUser(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update User with email = {user.Email}");

            return await _userService.UpdateAsync(user);
        }

        // DELETE api/Users
        [Route("{id}")]
        [HttpDelete]
        public async Task<IServiceResponse> RemoveUser(int id)
        {
            LoggerContext.Logger.Info($"Delete User with id = {id}");

            return await _userService.DeleteByIdAsync(id);
        }

        // GET api/Users/5
        [Route("")]
        [HttpGet]
        public async Task<IServiceResponse<EditUserDto>> GetUser(int id)
        {
            LoggerContext.Logger.Info($"Get User with id = {id}");

            return await _userService.GetByIdAsync(id);
        }

        // GET api/Users/?email=user@user.user
        [Route("")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IServiceResponse> CheckIfEmailAlreadyExists([FromUri] string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");

            return await _userService.CheckByEmailAsync(email);
        }

        [Route("")]
        [HttpGet]
        public async Task<IServiceResponse<IReadOnlyCollection<EditUserDto>>> GetUsers()
        {
            LoggerContext.Logger.Info("Get all users");

            return await _userService.GetAllAsync();
        }
    }
}