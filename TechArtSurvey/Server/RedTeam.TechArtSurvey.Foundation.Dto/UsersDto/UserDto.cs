using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class UserDto 
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        public string Password { get; set; }

        public RoleDto Role { get; set; }
    }
}