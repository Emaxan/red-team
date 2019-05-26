using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class TextDto : QuestionDto
    {
        [Required(AllowEmptyStrings = false)]
        public string InputType { get; set; }

        [Required]
        public LocalizableStringDto PlaceHolder { get; set; }
    }
}