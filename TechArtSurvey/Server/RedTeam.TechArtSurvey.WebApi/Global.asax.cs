using System.Web.Http;
using RedTeam.TechArtSurvey.WebApi.Filters;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace RedTeam.TechArtSurvey.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            

            RegisterWebApiFilters();
        }


        private void RegisterWebApiFilters()
        {
            
        }
    }
}