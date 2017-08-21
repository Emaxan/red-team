using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.WebApi.Owin;

namespace RedTeam.TechArtSurvey.WebApi.Authorization
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
            
            var serviceProvider = context.OwinContext.Get<IServiceProvider>();
            var userManager = serviceProvider.GetService<IUserService>();

            var result = await userManager.GetClaimsByCredentialsAsync(context.UserName, context.Password); //here UserName == Email
            if (result.Code != Foundation.Interfaces.ServiceResponses.ServiceResponseCode.Ok)
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