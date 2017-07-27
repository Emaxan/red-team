using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using RedTeam.TechArtSurvey.WebApi.Utils;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using Microsoft.Owin.Security.OAuth;

namespace RedTeam.TechArtSurvey.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new TechArtSurveyLoggerHandler());

            config.Services.Replace(typeof(IExceptionLogger), new TechArtSurveyExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new TechArtSurveyExceptionHandler());

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

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}