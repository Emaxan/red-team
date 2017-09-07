using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class ReadUserDto : UserDto
    {
        public int Id { get; set; }

        public RoleDto Role { get; set; }
    }
}