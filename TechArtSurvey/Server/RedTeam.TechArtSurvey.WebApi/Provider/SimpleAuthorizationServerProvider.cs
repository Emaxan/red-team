using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Security.Claims;

namespace RedTeam.TechArtSurvey.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IApplicationUserManager _userManager;


        public SimpleAuthorizationServerProvider(IApplicationUserManager userManager)
        {
            _userManager = userManager;
        }


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var result = await _userManager.GetClaimsByCredentialsAsync(context.UserName, context.Password); //here UserName == Email
            if (result.Code == Foundation.Interfaces.ServiceResponses.ServiceResponseCodes.Ok)
            {
                var identity = result.Content as ClaimsIdentity;
                context.Validated(identity);
            }
            else
            {
                context.Validated();
            }
        }
    }
}