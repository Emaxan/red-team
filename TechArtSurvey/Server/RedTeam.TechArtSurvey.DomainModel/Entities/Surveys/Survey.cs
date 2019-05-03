using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Survey : IEntity
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<SurveyVersion> Versions { get; set; }
    }
}