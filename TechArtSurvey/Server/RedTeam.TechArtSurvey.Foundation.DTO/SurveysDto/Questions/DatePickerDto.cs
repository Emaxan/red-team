using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class DatePickerDto : QuestionDto
    {
        [Required]
        public LocalizableStringDto PlaceHolder { get; set; }
    }
}