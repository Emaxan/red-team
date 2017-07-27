using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Security.Claims;
using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.WebApi.Provider
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        private IUserService _userService;
        public SimpleAuthorizationServerProvider(IUserService userService)
        {
            _userService = userService;
        }



        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //var result = await _userService.GetClaimsByCredentialsAsync(context.UserName, context.Password); //here UserName == Email
            //if (result.Code == Foundation.Interfaces.ServiceResponses.ServiceResponseCodes.Ok)
            //{
            //    var identity = result.Content as ClaimsIdentity;
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.Validated();
            //}
            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim("email", context.UserName));
            context.Validated(identity);
        }
    }
}