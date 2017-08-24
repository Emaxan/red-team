namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public interface IServiceResponse<TContent> : IServiceResponse
    {

    }

    public interface IServiceResponse
    {
        ServiceResponseCode Code { get; }

        object Content { get; }
    }
}