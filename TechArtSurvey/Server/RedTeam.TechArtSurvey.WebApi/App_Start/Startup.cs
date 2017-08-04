using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.WebApi.Provider;
using RedTeam.TechArtSurvey.WebApi.Filters;
using Ninject;
using Ninject.Web.Common.OwinHost;

[assembly: OwinStartup(typeof(RedTeam.TechArtSurvey.WebApi.App_Start.Startup))]

namespace RedTeam.TechArtSurvey.WebApi.App_Start
{
    public class Startup
    {
        HttpConfiguration _config;


        public void Configuration(IAppBuilder app)
        {
            _config = new HttpConfiguration();
            WebApiConfig.Register(_config);
            Configurate(_config);
            ConfigureOAuth(app);
            app.UseNinjectMiddleware(CreateKernel);
            app.UseWebApi(_config);
        }

        private IKernel CreateKernel()
        {
            var kernel = NinjectWebCommon.Create(_config);

            return kernel;
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }


        private void Configurate(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings
                            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Formatters
                .Remove(config.Formatters.XmlFormatter);

            config.Filters.Add(new ResponseFilterAttribute());
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}