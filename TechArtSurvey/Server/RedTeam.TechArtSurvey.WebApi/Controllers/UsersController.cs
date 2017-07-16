using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

using RedTeam.TechArtSurvey.Foundation.DTO;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/Users
        [HttpGet]
        [ResponseType(typeof( IReadOnlyCollection<UserDto> ))]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/Users/5
        [HttpGet]
        [ResponseType(typeof(UserDto))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetAsync(id);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
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
                var user = await _userService.GetUserByEmailAsync(email);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
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
                await _userService.Update(user);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch ( ArgumentException e )
            {
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
                var createdUserId = await _userService.Create(user);
                return CreatedAtRoute("DefaultApi", new
                                                    {
                                                        id = createdUserId
                                                    }, user);
            }
            catch ( ArgumentException e )
            {
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
                await _userService.DeleteAsync(user);
                return StatusCode(HttpStatusCode.Accepted);
            }
            catch ( ArgumentException e )
            {
                return BadRequest(e.Message);
            }
        }
    }
}