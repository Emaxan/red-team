using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Security.Claims;
using RedTeam.TechArtSurvey.WebApi.Provider;

[assembly: OwinStartup(typeof(RedTeam.TechArtSurvey.WebApi.App_Start.Startup))]

namespace RedTeam.TechArtSurvey.WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            //WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AuthorizeEndpointPath = new PathString("/api/account/authorization"),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }

    
}
