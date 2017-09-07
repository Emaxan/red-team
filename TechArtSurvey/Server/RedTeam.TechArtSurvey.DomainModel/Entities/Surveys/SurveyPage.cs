using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyPage : Page
    {
        public int SurveyVersionId { get; set; }

        public SurveyVersion SurveyVersion { get; set; }
    }
}