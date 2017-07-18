using System.Web.Http;

using RedTeam.TechArtSurvey.WebApi.Utils;

namespace RedTeam.TechArtSurvey.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new LoggerHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new
                {
                    id = RouteParameter.Optional
                }
            );

            // config.Formatters.Add(new UserFormatter());
        }
    }
}