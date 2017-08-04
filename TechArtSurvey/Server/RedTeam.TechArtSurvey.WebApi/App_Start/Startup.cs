using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.WebApi.Provider;
using RedTeam.TechArtSurvey.WebApi.Utils;
using RedTeam.TechArtSurvey.WebApi.Filters;

[assembly: OwinStartup(typeof(RedTeam.TechArtSurvey.WebApi.App_Start.Startup))]

namespace RedTeam.TechArtSurvey.WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);
            config.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Formatters
                .Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new ResponseFilterAttribute());
            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = NinjectDependencyResolver.Kernel.GetService(typeof(SimpleAuthorizationServerProvider)) as SimpleAuthorizationServerProvider,
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}