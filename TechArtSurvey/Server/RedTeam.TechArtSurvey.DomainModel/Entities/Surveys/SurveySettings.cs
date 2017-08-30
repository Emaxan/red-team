using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveySettings
    {
        public bool IsAnonymous { get; set; }

        public bool HasQuestionNumbers { get; set; }

        public bool HasPageNumbers { get; set; }

        public bool IsRandomOrdered { get; set; }

        public bool HasRequiredFieldsStars { get; set; }

        public bool HasProgressIndicator { get; set; }
    }
}