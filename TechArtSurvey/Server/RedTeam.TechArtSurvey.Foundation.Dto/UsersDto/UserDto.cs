using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class UserDto : SurveyAuthorDto
    {
        [Required]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        public string Password { get; set; }

        public RoleDto Role { get; set; }
    }
}