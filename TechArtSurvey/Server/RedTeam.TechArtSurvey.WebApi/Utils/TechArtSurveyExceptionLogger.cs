using System.Web.Http.ExceptionHandling;
using RedTeam.Logger;
using RedTeam.Logger.Interfaces;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class TechArtSurveyExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public TechArtSurveyExceptionLogger()
        {
            _log = LoggerFactory.GetLogger(GetType());
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Fatal(context.Exception.StackTrace, context.Exception);
        }
    }
}