using System;
using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyVersion : IEntity
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public string Title { get; set; }

        public SurveySettings Settings { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public ICollection<SurveyResponse> Responses { get; set; }

        public ICollection<SurveyPage> Pages { get; set; }
    }
}