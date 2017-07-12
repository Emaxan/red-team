using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using iTechArtSurvay.Domain.Models;
using iTechArtSurvay.Infrastructure.Repositores;
using iTechArtSurvay.Infrastructure.Repositores.Abstract;

namespace iTechArtSurvay.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        // GET api/Users/5
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return BadRequest("Wrong Id");
            }

            return Ok(user);
        }

        // PUT api/Users/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditUser(int id, User user)
        {
            userRepository.UpdateUser(user);
            return StatusCode(HttpStatusCode.Accepted);
        }

        // POST api/Users
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult AddUser(User user)
        {
            userRepository.CreateUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE api/Users/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult RemoveUser(int id)
        {
            var user = userRepository.GetUser(id);
            if (user == null)
            {
                return BadRequest("Wrong Id");
            }
            userRepository.DeleteUser(user);

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}