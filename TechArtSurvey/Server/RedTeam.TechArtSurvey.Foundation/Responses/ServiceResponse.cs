using System;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Responses
{
    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseCodes Code { get; set; }

        public object Content { get; set; }


        private ServiceResponse(ServiceResponseCodes code, object content = null)
        {
            Code = code;
            Content = content;
        }


        public static ServiceResponse CreateSuccessful(object content)
        {
            return new ServiceResponse(ServiceResponseCodes.Ok, content);
        }

        public static ServiceResponse CreateUnsuccessful(ServiceResponseCodes code)
        {
            if (code == ServiceResponseCodes.Ok)
            {
                throw new ArgumentException("Invalid code.");
            }

            return new ServiceResponse(code);
        }
    }
}