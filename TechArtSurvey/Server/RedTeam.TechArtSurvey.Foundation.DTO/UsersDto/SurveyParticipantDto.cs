using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class SurveyParticipantDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
    }
}