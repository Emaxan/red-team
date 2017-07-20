using System.Web.Http.ExceptionHandling;
using RedTeam.Logger;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            LoggerContext.Logger.Fatal(context.Exception.StackTrace + context.Exception, context.Exception);
        }
    }
}