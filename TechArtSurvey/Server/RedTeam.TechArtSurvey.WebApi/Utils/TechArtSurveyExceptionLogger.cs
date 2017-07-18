using System.Web.Http.ExceptionHandling;
using RedTeam.Logger;
using RedTeam.Logger.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyExceptionLogger : ExceptionLogger
    {

        public override void Log(ExceptionLoggerContext context)
        {
            LoggerContext.GetLogger.Fatal(context.Exception.StackTrace, context.Exception);
        }
    }
}