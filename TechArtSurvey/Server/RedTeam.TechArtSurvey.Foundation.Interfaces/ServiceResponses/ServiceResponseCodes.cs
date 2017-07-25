namespace RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses
{
    public enum ServiceResponseCodes
    {
        Ok,
        NotFoundUserById,
        NotFoundUserByEmail,
        UserAlreadyExists,
        InvalidPassword,
        NeedToRefreshToken,
        NotFoundByToken,
        TokenNotFound
    }
}