using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class BarRatingDto : QuestionDto
    {
        [Required(AllowEmptyStrings = false)]
        public string ChoicesOrder { get; set; }
    }
}