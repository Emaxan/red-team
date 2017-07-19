using System.Threading.Tasks;
using System.Web.Http;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.WebApi.Filters;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    [ResponseFilter]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // POST api/Users
        [HttpPost]
        public async Task<IServiceResponse> AddUser(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Create User with email = {user.Email}");
            return await _userService.CreateAsync(user);
        }

        // PUT api/Users/5
        [HttpPut]
        public async Task<IServiceResponse> EditUser(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Update User with email = {user.Email}");
            return await _userService.UpdateAsync(user);
        }

        // DELETE api/Users
        [HttpDelete]
        public async Task<IServiceResponse> RemoveUser(UserDto user)
        {
            LoggerContext.GetLogger.Info($"Delete User with email = {user.Email}");
            return await _userService.DeleteAsync(user);
        }

        // GET api/Users/5
        [HttpGet]
        public async Task<IServiceResponse> GetUser(int id)
        {
            LoggerContext.GetLogger.Info($"Get User with id = {id}");
            return await _userService.GetByIdAsync(id);
        }

        // GET api/Users/?email=user@user.user
        [HttpGet]
        public async Task<IServiceResponse> GetUserByEmail([FromUri] string email)
        {
            LoggerContext.GetLogger.Info($"Get User with email = {email}");
            return await _userService.GetByEmailAsync(email);
        }

        // GET api/Users
        [HttpGet]
        public async Task<IServiceResponse> GetUsers()
        {
            LoggerContext.GetLogger.Info("Get all users");
            return await _userService.GetAllAsync();
        }
    }
}