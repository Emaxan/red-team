using System.Collections.Generic;
using System.Net;
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
        public IEnumerable<UserDto> GetUsers()
        {
            return _userService.GetAll();
        }

        // GET api/Users/5
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userService.Get(id);
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
        public IHttpActionResult RemoveUser(int id)
        {
            _userService.Delete(id);
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