namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public interface IServiceResponse
    {
        ServiceResponseCode Code { get; }

        object Content { get; }
    }
}