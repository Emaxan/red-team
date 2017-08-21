using System;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Responses
{
    public class ServiceResponse<TContent> : IServiceResponse
    {
        public ServiceResponseCodes Code { get; set; }

        public object Content { get; set; }


        private ServiceResponse(ServiceResponseCodes code, TContent content = default(TContent))
        {
            Code = code;
            Content = content;
        }


        public static ServiceResponse<TContent> CreateSuccessful(TContent content)
        {
            return new ServiceResponse<TContent>(ServiceResponseCodes.Ok, content);
        }

        public static ServiceResponse<TContent> CreateUnsuccessful(ServiceResponseCodes code)
        {
            if (code == ServiceResponseCodes.Ok)
            {
                throw new ArgumentException("Invalid code.");
            }

            return new ServiceResponse<TContent>(code);
        }
    }
}