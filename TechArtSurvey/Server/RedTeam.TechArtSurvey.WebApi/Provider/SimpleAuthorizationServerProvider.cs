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

            var result = _userService.GetClaimsByCredentialsAsync(context.UserName, context.Password); //here UserName == Email
            if (result.Result.Code == Foundation.Interfaces.ServiceResponses.ServiceResponseCodes.Ok)
            {
                var identity = result.Result.Content as ClaimsIdentity;
                context.Validated(identity);
            }
            else
            {
                context.Validated();
            }
        }
    }
}