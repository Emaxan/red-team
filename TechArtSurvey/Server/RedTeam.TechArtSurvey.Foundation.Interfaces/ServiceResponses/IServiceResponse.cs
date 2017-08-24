namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public interface IServiceResponse<out TContent> : IServiceResponse
    {
        new TContent Content { get; }
    }

    public interface IServiceResponse
    {
        ServiceResponseCode Code { get; }

        object Content { get; }
    }
}