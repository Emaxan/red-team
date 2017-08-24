using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.WebApi.Properties;

namespace RedTeam.TechArtSurvey.WebApi
{
    public class ResponseFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(actionContext.ModelState.IsValid)
            {
                return;
            }

            var errors = new List<string>();
            foreach(var state in actionContext.ModelState)
            {
                errors.AddRange(state.Value.Errors.Select(em => em.ErrorMessage));
            }

            var json = JsonConvert.SerializeObject(errors);
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, json);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response?.Content as ObjectContent;
            var serviceResponse = objectContent?.Value as IServiceResponse;
            if(serviceResponse == null)
            {
                return;
            }

            HttpResponseMessage response;

            if(serviceResponse.Code == ServiceResponseCode.Ok)
            {
                response = actionExecutedContext.Request.CreateResponse(
                                                                        HttpStatusCode.OK,
                                                                        serviceResponse.Content);
            }
            else
            {
                var errorMessages = new List<string>
                                    {
                                        ResponseMessages.ResourceManager.GetString(serviceResponse.Code.ToString())
                                    };
                var json = JsonConvert.SerializeObject(errorMessages);
                response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, json);
                LoggerContext.Logger.Error(errorMessages[0]);
            }

            actionExecutedContext.Response = response;
        }
    }
}