using System;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.WebApi.Controllers {
	public class UsersController : ApiController {
		//private UserContext db = new UserContext();

		public IHttpActionResult GetUsers() {
			return new NotFoundResult(Request);
		}

		public IHttpActionResult GetUser(int id) {
			return new NotFoundResult(Request);
		}

		[ResponseType(typeof(void))]
		public IHttpActionResult PutUser(int id, User user) {
			return new NotFoundResult(Request);
		}

		[ResponseType(typeof(User))]
		public IHttpActionResult PostUser(User user) {
			return new NotFoundResult(Request);
		}

		[ResponseType(typeof(User))]
		public IHttpActionResult DeleteUser(int id) {
			return new NotFoundResult(Request);
		}

		protected override void Dispose(bool disposing)
		{
			//if (disposing) db.Dispose();
			base.Dispose(disposing);
		}

		private bool UserExist(int id) {
			return false;
		}
	}
}