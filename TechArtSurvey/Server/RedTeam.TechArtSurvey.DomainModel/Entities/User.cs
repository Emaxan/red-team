using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}