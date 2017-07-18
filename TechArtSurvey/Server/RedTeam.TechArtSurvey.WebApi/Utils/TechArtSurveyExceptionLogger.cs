using System.Web.Http.ExceptionHandling;
using RedTeam.Logger.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public TechArtSurveyExceptionLogger(ILog log)
        {
            _log = log;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Fatal(context.Exception.StackTrace, context.Exception);
        }
    }
}