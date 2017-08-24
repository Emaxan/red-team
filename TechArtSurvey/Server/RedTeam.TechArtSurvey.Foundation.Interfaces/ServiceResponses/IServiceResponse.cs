namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public interface IServiceResponse<TContent>
    {
        ServiceResponseCode Code { get; }

        TContent Content { get; }
    }
}