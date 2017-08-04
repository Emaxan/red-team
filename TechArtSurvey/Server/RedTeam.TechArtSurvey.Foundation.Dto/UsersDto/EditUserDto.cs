namespace RedTeam.TechArtSurvey.Foundation.Dto.UsersDto
{
    public class EditUserDto : UserDto
    {
        public int Id { get; set; }

        public RoleDto Role { get; set; }
    }

    public class RoleDto
    {
        public string Name { get; set; }
    }
}