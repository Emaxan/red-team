using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class RatingDto : QuestionDto
    {
        [Required]
        public LocalizableStringDto MinRateDescription { get; set; }

        [Required]
        public LocalizableStringDto MaxRateDescription { get; set; }
    }
}