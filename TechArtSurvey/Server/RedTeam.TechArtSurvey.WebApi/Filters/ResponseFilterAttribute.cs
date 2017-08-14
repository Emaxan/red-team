using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RedTeam.TechArtSurvey.WebApi.Filters
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in actionContext.ModelState)
                {
                    errors.Add(state.Value.Errors[0].ErrorMessage);
                }
                var json = JsonConvert.SerializeObject(errors);
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, json);
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
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
                            List<string> errorMessages = new List<string>();
                            errorMessages.Add(Properties.ResponseMessages.ResourceManager.GetString(serviceResponse.Code.ToString()));
                            var json = JsonConvert.SerializeObject(errorMessages);
                            response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, json);
                            LoggerContext.Logger.Error(errorMessages[0]);
                        }

                        actionExecutedContext.Response = response;
                    }
                }
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}