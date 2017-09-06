using System.Collections.Generic;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionAnswerDto
    {
        public SurveyResponseDto SurveyResponse { get; set; }
        
        public QuestionDto Question { get; set; }

        public string Value { get; set; }

        public ICollection<QuestionVariantDto> Variants { get; set; }
    }
}