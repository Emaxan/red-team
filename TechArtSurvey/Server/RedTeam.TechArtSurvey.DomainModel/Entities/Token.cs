using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime Since { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}