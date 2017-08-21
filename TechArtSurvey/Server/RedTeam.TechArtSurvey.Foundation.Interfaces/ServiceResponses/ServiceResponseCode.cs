namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public enum ServiceResponseCode
    {
        Ok,
        UserNotFoundById,
        UserNotFoundByEmail,
        UserAlreadyExists,
        InvalidPassword,
        TokenExpired,
        TokenNotFound
    }
}