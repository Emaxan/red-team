using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class Token
    {
        public Guid Id { get; set; }
        public DateTime Since { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}