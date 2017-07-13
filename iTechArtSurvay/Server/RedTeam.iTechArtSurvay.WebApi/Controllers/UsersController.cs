using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RedTeam.iTechArtSurvay.Foundation.DTO;
using RedTeam.iTechArtSurvay.Foundation.Interfaces;

namespace RedTeam.iTechArtSurvay.WebApi.Controllers
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
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/Users/5
        [HttpGet]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            var user = await _userService.GetAsync(id);
            if ( user == null )
            {
                return BadRequest("Wrong Id");
            }

            return Ok(user);
        }

        // PUT api/Users/5
        [HttpPut]
        [ResponseType(typeof( void ))]
        public IHttpActionResult EditUser(int id, UserDto user)
        {
            _userService.Update(user);
            return StatusCode(HttpStatusCode.Accepted);
        }

        // POST api/Users
        [HttpPost]
        [ResponseType(typeof( UserDto ))]
        public IHttpActionResult AddUser(UserDto user)
        {
            _userService.Create(user);
            return CreatedAtRoute("DefaultApi", new
                                                {
                                                    id = user.Id
                                                }, user);
        }

        // DELETE api/Users/5
        [HttpDelete]
        [ResponseType(typeof( UserDto ))]
        public async Task<IHttpActionResult> RemoveUser(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if ( disposing )
            {
                _userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}