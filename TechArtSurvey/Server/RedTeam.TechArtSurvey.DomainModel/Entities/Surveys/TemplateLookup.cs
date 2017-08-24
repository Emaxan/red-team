using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class TemplateLookup
    {
        public int PageId { get; set; }

        public int TemplateId { get; set; }

        public Template Template { get; set; }

        public SurveyPage SurveyPage { get; set; }
    }
}