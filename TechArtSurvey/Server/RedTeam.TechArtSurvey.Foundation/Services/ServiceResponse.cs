using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    public class ServiceResponse : IServiceResponse
    {
        public ServiceResponseCodes Code { get; set; }
        public object Content { get; set; }
    }
}