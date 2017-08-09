using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IApplicationUserManager _userManager;


        public UsersController(IApplicationUserManager userManager)
        {
            _userManager = userManager;
        }


        // PUT api/Users/5
        [Route("{user}")]
        [HttpPut]
        public async Task<IServiceResponse> EditUser(EditUserDto user)
        {
            LoggerContext.Logger.Info($"Update User with email = {user.Email}");

            return await _userManager.UpdateAsync(user);
        }

        // DELETE api/Users
        [Route("{id}")]
        [HttpDelete]
        public async Task<IServiceResponse> RemoveUser(int id)
        {
            LoggerContext.Logger.Info($"Delete User with id = {id}");

            return await _userManager.DeleteByIdAsync(id);
        }

        // GET api/Users/5
        [Route("")]
        [HttpGet]
        public async Task<IServiceResponse> GetUser(int id)
        {
            LoggerContext.Logger.Info($"Get User with id = {id}");

            return await _userManager.GetByIdAsync(id);
        }

        // GET api/Users/?email=user@user.user
        [Route("")]
        [HttpGet]
        public async Task<IServiceResponse> CkeckIfEmailAlreadyExists([FromUri] string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");

            return await _userManager.CheckByEmailAsync(email);
        }

        [Route("")]
        [HttpGet]
        public async Task<IServiceResponse> GetUsers()
        {
            LoggerContext.Logger.Info("Get all users");

            return await _userManager.GetAllAsync();
        }
    }
}