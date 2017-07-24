using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{
    class AuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        private const string _authCookieName = "AUTHENTICATION";

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var httpContext = HttpContext.Current;
            if (httpContext.Request.Cookies[_authCookieName] != null)
            {
                string[] roles = new string[] { "user" }; //must be got from DB

                //must be compared with db:
                string login = httpContext.Request.Cookies[_authCookieName]["user"];
                string token = httpContext.Request.Cookies[_authCookieName]["token"]; 
                string tokenExpires = httpContext.Request.Cookies[_authCookieName]["tokenExpires"];
                context.Principal = new GenericPrincipal(new GenericIdentity(login), roles);
            }
            
            if (context.Principal == null)
            {
                context.ErrorResult
                = new UnauthorizedResult(new AuthenticationHeaderValue[] {
                    new AuthenticationHeaderValue("Basic") }, context.Request);
            }
            return Task.FromResult<object>(null);
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context,
                                    CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}