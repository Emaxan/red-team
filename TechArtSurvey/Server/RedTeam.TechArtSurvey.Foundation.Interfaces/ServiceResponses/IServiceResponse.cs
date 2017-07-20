namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public interface IServiceResponse
    {
        ServiceResponseCodes Code { get; set; }

        object Content { get; set; }
    }
}