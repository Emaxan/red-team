using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Security.Claims;

namespace RedTeam.TechArtSurvey.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //var result = await _service.GetUserByCredentialsAsync(context.UserName, context.Password);
            //var user = result.Content;
            //if (user != null)
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //    identity.AddClaim(new Claim("user", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));

            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.Validated();
            //}

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("user", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
}