using System.Web.Http.ExceptionHandling;
using RedTeam.Logger;

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
            string message = context.Exception.Message;
            // use log
        }
    }
}