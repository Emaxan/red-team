using System;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Responses
{
    public class ServiceResponse<TContent> : ServiceResponse, IServiceResponse<TContent>
    {
        public new TContent Content => (TContent)base.Content;


        internal ServiceResponse(ServiceResponseCode code, TContent content = default(TContent)) : base(code, content)
        {
        }
    }

    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseCode Code { get; }

        public object Content { get; }


        protected ServiceResponse(ServiceResponseCode code, object content = null)
        {
            Code = code;
            Content = content;
        }


        public static ServiceResponse<T> CreateSuccessful<T>(T content)
        {
            return new ServiceResponse<T>(ServiceResponseCode.Ok, content);
        }

        public static ServiceResponse CreateSuccessful()
        {
            return new ServiceResponse(ServiceResponseCode.Ok);
        }

        public static ServiceResponse<T> CreateUnsuccessful<T>(ServiceResponseCode code)
        {
            if (code == ServiceResponseCode.Ok)
            {
                throw new ArgumentException("Invalid code.");
            }

            return new ServiceResponse<T>(code);
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