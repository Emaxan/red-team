using Microsoft.AspNet.Identity;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class User: IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }

        public Role Role { get; set; }
    }
}