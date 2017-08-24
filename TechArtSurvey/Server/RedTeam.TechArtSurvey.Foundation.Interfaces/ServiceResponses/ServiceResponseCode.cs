namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public enum ServiceResponseCode
    {
        Ok,
        UserNotFoundById,
        UserNotFoundByEmail,
        UserAlreadyExists,
        InvalidCredentials,
        TokenExpired,
        TokenNotFound
    }
}