namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class ResetPasswordDto
    {
        public int UserId { get; set; }
        public string ResetPasswordToken { get; set; }
        public string NewPassword { get; set; }
    }
}