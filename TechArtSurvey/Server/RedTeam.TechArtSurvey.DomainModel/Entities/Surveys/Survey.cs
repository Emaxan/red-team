using System;
using System.Collections.Generic;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Survey
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<SurveyVersion> Versions { get; set; }
    }
}