using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using iTechArtSurvay.Domain.Models;
using iTechArtSurvay.Infrastructure.Repositores;

namespace iTechArtSurvay.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IRepository<User> usersRepository;

        public UsersController(IRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        // GET api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return usersRepository.GetAll();
        }

        // GET api/Users/5
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = usersRepository.Get(id);
            if (user == null) return BadRequest("Wrong Id");
            return Ok(user);
        }

        // PUT api/Users/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult EditUser(int id, User user)
        {
            usersRepository.Update(user);
            return Ok(user);
        }

        // POST api/Users
        [HttpPost]
        [ResponseType(typeof(User))]
        public IHttpActionResult AddUser(User user)
        {
            usersRepository.Add(user);
            return Ok(user);
        }

        // DELETE api/Users/5
        [HttpDelete]
        [ResponseType(typeof(User))]
        public IHttpActionResult RemoveUser(int id)
        {
            var user = usersRepository.Get(id);
            if (user == null) return BadRequest("Wrong Id");
            usersRepository.Delete(user);
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}