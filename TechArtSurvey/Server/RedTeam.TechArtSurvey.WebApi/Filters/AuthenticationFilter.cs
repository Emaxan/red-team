using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{

    public class AuthorizationAttribute : AuthorizeAttribute
    {
        private const string _authCookieName = "AUTHENTICATION";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var httpContext = HttpContext.Current;
            httpContext.User = new GenericPrincipal(new GenericIdentity(""), null);
            if (httpContext.Request.Cookies[_authCookieName] != null)
            {
                string[] roles = new string[] { "user" }; //must be got from DB

                //must be compared with db:
                string token = httpContext.Request.Cookies[_authCookieName]["token"];
                httpContext.User = new GenericPrincipal(new GenericIdentity("user@user.user"), roles);
            }

            if (!SkipAuthorization(actionContext) && httpContext.User == null)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

    }
}