using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Survey
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public string Title { get; set; }

        public int SettingsId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public int AuthorId { get; set; }

        public User User { get; set; }

        public SurveySettings Settings { get; set; }

        public ICollection<SurveyResponse> SurveyResponse { get; set; }

        public ICollection<SurveyLookup> SurveyLookups { get; set; }
    }
}