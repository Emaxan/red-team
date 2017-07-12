using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace iTechArtSurvay.WebApi.Filters {
    internal class CustomAuthenticationAttribute : Attribute, IAuthenticationFilter {
        /// <summary>Authenticates the request.</summary>
        /// <returns>A Task that will perform authentication.</returns>
        /// <param name="context">The authentication context.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken) {
            context.Principal = null;
            var authentication = context.Request.Headers.Authorization;
            if ( authentication != null && authentication.Scheme == "Basic" ) {
                var authData = Encoding.ASCII.GetString(Convert.FromBase64String(authentication.Parameter)).Split(':');
                string[] roles = {"user"};
                var login = authData[0];
                context.Principal = new GenericPrincipal(new GenericIdentity(login), roles);
            }
            if ( context.Principal == null )
                context.ErrorResult
                    = new UnauthorizedResult(
                        new[] {
                                  new AuthenticationHeaderValue("Basic")
                              },
                        context.Request);
            return Task.FromResult<object>(null);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken) {
            return Task.FromResult<object>(null);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether more than one instance of the indicated attribute can be specified for
        ///     a single program element.
        /// </summary>
        /// <returns>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</returns>
        public bool AllowMultiple {
            get { return false; }
        }
    }
}