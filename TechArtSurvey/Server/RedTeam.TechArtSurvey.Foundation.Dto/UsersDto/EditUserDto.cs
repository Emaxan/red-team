using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class EditUserDto : ReadUserDto
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        public string Password { get; set; }
    }
}