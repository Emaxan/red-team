using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace iTechArtSurvay.WebApi.Filters {
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter {
        private readonly string[] usersList;

        public CustomAuthorizationAttribute(params string[] users) {
            usersList = users;
        }

        /// <summary>Executes the authorization filter to synchronize.</summary>
        /// <returns>The authorization filter to synchronize.</returns>
        /// <param name="actionContext">The action context.</param>
        /// <param name="cancellationToken">The cancellation token associated with the filter.</param>
        /// <param name="continuation">The continuation.</param>
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation) {
            var principal = actionContext.RequestContext.Principal;
            if ( principal == null || !usersList.Contains(principal.Identity.Name) )
                return Task.FromResult(
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            return continuation();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for
        ///     a single program element.
        /// </summary>
        /// <returns>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</returns>
        public bool AllowMultiple => false;
    }
}