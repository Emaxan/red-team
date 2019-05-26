using System.Collections.Generic;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionAnswerDto
    {
        public SurveyResponseDto SurveyResponse { get; set; }
        
        public QuestionResponseDto Question { get; set; }

        public string Value { get; set; }

        public ICollection<QuestionVariantResponseDto> Variants { get; set; }
    }
}