using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using RedTeam.TechArtSurvey.WebApi.Utils;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;
using System.Linq;
using RedTeam.TechArtSurvey.WebApi.Provider;

namespace RedTeam.TechArtSurvey.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new TechArtSurveyLoggerHandler());
            config.Services.Replace(typeof(IExceptionLogger), new TechArtSurveyExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new TechArtSurveyExceptionHandler());
            config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api"));
            log4net.Config.XmlConfigurator.Configure();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}