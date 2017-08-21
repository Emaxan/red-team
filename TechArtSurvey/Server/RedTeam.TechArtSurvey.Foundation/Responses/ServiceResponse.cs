using System;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Responses
{
    public class ServiceResponse<TContent> : ServiceResponse
    {
        public new TContent Content => (TContent)base.Content;


        internal ServiceResponse(ServiceResponseCode code, TContent content = default(TContent)) : base(code, content)
        {
        }

        public static ServiceResponse<TContent> CreateSuccessful(TContent content)
        {
            return new ServiceResponse<TContent>(ServiceResponseCode.Ok, content);
        }
    }

    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseCode Code { get; private set; }

        public object Content { get; private set; }


        protected ServiceResponse(ServiceResponseCode code, object content = null)
        {
            Code = code;
            Content = content;
        }


        public static ServiceResponse CreateSuccessful(object content)
        {
            return new ServiceResponse(ServiceResponseCode.Ok, content);
        }

        public static ServiceResponse CreateUnsuccessful(ServiceResponseCode code)
        {
            if (code == ServiceResponseCode.Ok)
            {
                throw new ArgumentException("Invalid code.");
            }

            return new ServiceResponse(code);
        }
    }
}