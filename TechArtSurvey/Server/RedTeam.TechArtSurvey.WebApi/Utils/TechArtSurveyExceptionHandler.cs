using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace RedTeam.TechArtSurvey.WebApi.Utils
{
    public class ExceptionHttpResponse : IHttpActionResult
    {
        private readonly string _errorMessage;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;

        public ExceptionHttpResponse(
            HttpRequestMessage requestMessage, 
            HttpStatusCode statusCode,
            string errorMessage)
        {
            _requestMessage = requestMessage;
            _statusCode = statusCode;
            _errorMessage = errorMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode, _errorMessage));
        }
    }

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