using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using RedTeam.TechArtSurvey.WebApi.Provider;
using RedTeam.TechArtSurvey.WebApi.Filters;
using Ninject;
using Ninject.Web.Common.OwinHost;
using RedTeam.TechArtSurvey.WebApi.Formats;
using RedTeam.TechArtSurvey.WebApi.Options;
using JetBrains.Annotations;

[assembly: OwinStartup(typeof(RedTeam.TechArtSurvey.WebApi.App_Start.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace RedTeam.TechArtSurvey.WebApi.App_Start
{
    public class Startup
    {
        private HttpConfiguration _config;

        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            _config = new HttpConfiguration();
            WebApiConfig.Register(_config);
            Configurate(_config);
            ConfigureOAuth(app);
            app.UseNinjectMiddleware(CreateKernel);
            app.UseWebApi(_config);
        }
        
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider(),
                AccessTokenFormat = new CustomJwtFormat()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseJwtBearerAuthentication(new JwtOptions());
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

        private IKernel CreateKernel()
        {
            var kernel = NinjectWebCommon.Create(_config);

            return kernel;
        }
    }
}