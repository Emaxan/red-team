using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
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
                        response = actionExecutedContext.Request.CreateResponse(
                            HttpStatusCode.BadRequest,
                            Properties.ResponseMessages.ResourceManager.GetString(serviceResponse.Code.ToString()));
                    }

                    actionExecutedContext.Response = response;
                    base.OnActionExecuted(actionExecutedContext);
                }
            }
        }
    }
}