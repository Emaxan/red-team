using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response =
                    actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var serviceResponse = objectContent.Value as IServiceResponse;
                if (serviceResponse != null)
                {
                    HttpResponseMessage response = actionExecutedContext.Response;

                    if (serviceResponse.Code == ServiceResponseCodes.Ok)
                    {
                        response = actionExecutedContext.Request.CreateResponse(
                            HttpStatusCode.OK,
                            serviceResponse.Content);
                    }
                    else
                    {
                        string errorMessage =
                            Properties.ResponseMessages.ResourceManager.GetString(serviceResponse.Code.ToString());

                        response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, errorMessage);
                        LoggerContext.GetLogger.Error(errorMessage);
                    }

                    actionExecutedContext.Response = response;
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}