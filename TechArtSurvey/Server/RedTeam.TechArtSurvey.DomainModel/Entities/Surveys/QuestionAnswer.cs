using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class QuestionAnswer
    {
        public int SurveyResponseId { get; set; }

        public SurveyResponse SurveyResponse { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Value { get; set; }

        public ICollection<QuestionVariant> Variants { get; set; }
    }
}