using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

using RedTeam.Logger.Interfaces;
using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
        private readonly ILog _log;

        public UsersController(IUserService userService, ILog log)
        {
            _userService = userService;
            _log = log;
        }

        // GET api/Users
        [HttpGet]
        [ResponseType(typeof( IReadOnlyCollection<UserDto> ))]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            _log.Info("Get all users");
            return await _userService.GetAllAsync();
        }

        // GET api/Users/5
        [HttpGet]
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            try
            {
                _log.Info($"Get User with id = {id}");
                var user = await _userService.GetAsync(id);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                _log.Error($"Get User with id. Error: {e.Message}", e);
                return BadRequest(e.Message);
            }
        }

        // GET api/Users/?email=user@user.user
        [HttpGet]
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetUserByEmail([FromUri] string email)
        {
            try
            {
                _log.Info($"Get User with email = {email}");
                var user = await _userService.GetUserByEmailAsync(email);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                _log.Error($"Get User with email. Error: {e.Message}", e);
                return BadRequest(e.Message);
            }
        }

        // PUT api/Users/5
        [HttpPut]
        [ResponseType(typeof( void ))]
        public async Task<IHttpActionResult> EditUser(UserDto user)
        {
            try
            {
                _log.Info($"Update User with email = {user.Email}");
                await _userService.Update(user);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch ( ArgumentException e )
            {
                _log.Error($"Update User. Error: {e.Message}", e);
                return BadRequest(e.Message);
            }
        }

        // POST api/Users
        [HttpPost]
        [ResponseType(typeof( void ))]
        public async Task<IHttpActionResult> AddUser(UserDto user)
        {
            try
            {
                _log.Info($"Create User with email = {user.Email}");
                var createdUserId = await _userService.Create(user);
                return CreatedAtRoute("DefaultApi", new
                                                    {
                                                        id = createdUserId
                                                    }, user);
            }
            catch ( ArgumentException e )
            {
                _log.Error($"Greate User. Error: {e.Message}", e);
                return BadRequest(e.Message);
            }
        }

        // DELETE api/Users
        [HttpDelete]
        [ResponseType(typeof( void ))]
        public async Task<IHttpActionResult> RemoveUser(UserDto user)
        {
            try
            {
                _log.Info($"Delete User with email = {user.Email}");
                await _userService.DeleteAsync(user);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch ( ArgumentException e )
            {
                _log.Error($"Delete User. Error: {e.Message}", e);
                return BadRequest(e.Message);
            }
        }
    }
}