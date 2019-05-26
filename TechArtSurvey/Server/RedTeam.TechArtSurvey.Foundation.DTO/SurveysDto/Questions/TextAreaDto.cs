using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class TextAreaDto : QuestionDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Rows { get; set; }

        [Required]
        public LocalizableStringDto PlaceHolder { get; set; }
    }
}