using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation
{
    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseCodes Code { get; set; }

        public object Content { get; set; }
    }
}