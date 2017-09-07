using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class TemplatePage : Page
    {
        public int TemplateId { get; set; }

        public SurveyTemplate Template { get; set; }
    }
}