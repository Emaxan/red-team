namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public enum ServiceResponseCodes
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