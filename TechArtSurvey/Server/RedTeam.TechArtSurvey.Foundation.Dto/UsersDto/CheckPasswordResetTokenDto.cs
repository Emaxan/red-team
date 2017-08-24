namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class CheckPasswordResetTokenDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}