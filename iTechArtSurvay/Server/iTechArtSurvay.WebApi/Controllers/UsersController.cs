using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using iTechArtSurvay.Domain;

namespace iTechArtSurvay.WebApi.Controllers {
    public class UsersController : ApiController {
        //private UserContext db = new UserContext();

        // GET api/Users
        public IHttpActionResult GetUsers() {
            return new NotFoundResult(Request);
        }

        // GET api/User/5
        public IHttpActionResult GetUser(int id) {
            return new NotFoundResult(Request);
        }

        // PUT api/Users/5
        [ResponseType(typeof( void ))]
        public IHttpActionResult PutUser(int id, User user) {
            return new NotFoundResult(Request);
        }

        // POST api/Users
        [ResponseType(typeof( User ))]
        public IHttpActionResult PostUser(User user) {
            return new NotFoundResult(Request);
        }

        // DELETE api/Users/5
        [ResponseType(typeof( User ))]
        public IHttpActionResult DeleteUser(int id) {
            return new NotFoundResult(Request);
        }

        protected override void Dispose(bool disposing) {
            //if (disposing) db.Dispose();
            base.Dispose(disposing);
        }

        private bool UserExist(int id) {
            return false; //return db.Users.Count(user => user.Id == id) > 0;
        }
    }
}