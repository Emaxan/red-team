using System.Web.Http;
using RedTeam.TechArtSurvey.WebApi.Filters;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace RedTeam.TechArtSurvey.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            RegisterWebApiFilters();
        }


        private void RegisterWebApiFilters()
        {
            GlobalConfiguration.Configuration.Filters.Add(new ResponseFilterAttribute());
        }
    }
}