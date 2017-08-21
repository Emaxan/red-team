using System;
using System.Web.Http;
using Autofac.Integration.WebApi;
using JetBrains.Annotations;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RedTeam.TechArtSurvey.WebApi.Authorization;
using RedTeam.TechArtSurvey.WebApi.Conf;
using RedTeam.TechArtSurvey.WebApi.DI;
using RedTeam.TechArtSurvey.WebApi.Owin;

[assembly: OwinStartup(typeof(Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace RedTeam.TechArtSurvey.WebApi.Conf
{
    public class Startup
    {
        private HttpConfiguration _config;

        [UsedImplicitly]
        public void Configuration(IAppBuilder app)
        {
            _config = new HttpConfiguration();

            var container = AutofacConfigurator.Configure("TechArtSurveyContext");
            _config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);

            WebApiConfig.Register(_config);

            app.CreateInstancePerOwinContext<IServiceProvider>(ctx => new AutofacServiceProvider(ctx));

            Configurate(_config);
            ConfigureOAuth(app);

            app.UseAutofacWebApi(_config);
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
    }
}