using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyPage
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Number { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<SurveyLookup> SurveyLookups { get; set; }

        public ICollection<TemplateLookup> TemplateLookups { get; set; }
    }
}