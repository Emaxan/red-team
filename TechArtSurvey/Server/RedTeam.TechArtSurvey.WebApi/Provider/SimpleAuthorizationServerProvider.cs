using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Security.Claims;
using Ninject;
using RedTeam.TechArtSurvey.WebApi.Utils;
using Microsoft.Owin.Security;

namespace RedTeam.TechArtSurvey.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return Task.FromResult(0);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var kernel = NinjectDependencyResolver.Kernel;
            var userManager = kernel.Get<IUserService>();

            var result = await userManager.GetClaimsByCredentialsAsync(context.UserName, context.Password); //here UserName == Email
            if (result.Code != Foundation.Interfaces.ServiceResponses.ServiceResponseCodes.Ok)
            {
                context.Validated();
            }
            else
            {
                var identity = result.Content as ClaimsIdentity;
                var props = new AuthenticationProperties();
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
        }
    }
}