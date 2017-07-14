using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.DTO
{
    public class UserDto : IEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}