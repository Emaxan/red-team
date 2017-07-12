using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using iTechArtSurvay.Data.Infrastructure;
using iTechArtSurvay.Data.Repositories;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IRepository<User> _users = new UserRepository();

        // GET api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _users.GetAll();
        }

        // GET api/Users/5
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = _users.Get(id);
            if ( user == null ) return BadRequest("Wrong Id");
            return Ok(user);
        }

        // PUT api/Users/5
        [HttpPut]
        [ResponseType(typeof( void ))]
        public IHttpActionResult EditUser(int id, User user)
        {
            _users.Update(user);
            return Ok(user);
        }

        // POST api/Users
        [HttpPost]
        [ResponseType(typeof( User ))]
        public IHttpActionResult AddUser(User user)
        {
            _users.Add(user);
            return Ok(user);
        }

        // DELETE api/Users/5
        [HttpDelete]
        [ResponseType(typeof( User ))]
        public IHttpActionResult RemoveUser(int id)
        {
            var user = _users.Get(id);
            if ( user == null ) return BadRequest("Wrong Id");
            _users.Delete(user);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}