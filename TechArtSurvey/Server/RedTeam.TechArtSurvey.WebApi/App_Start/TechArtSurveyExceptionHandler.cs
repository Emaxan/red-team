using System.Net;
using System.Web.Http.ExceptionHandling;

namespace RedTeam.TechArtSurvey.WebApi.App_Start
{
    public class TechArtSurveyExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ExceptionHttpResponse(
                context.Request, HttpStatusCode.InternalServerError, 
                context.Exception.Message);
        }
    }
}