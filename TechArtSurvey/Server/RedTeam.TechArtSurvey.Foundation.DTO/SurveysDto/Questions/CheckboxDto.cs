using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class CheckboxDto : QuestionDto
    {
        [Required]
        public bool HasOther { get; set; }

        [Required]
        public LocalizableStringDto OtherText { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ColCount { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string ChoicesOrder { get; set; }
    }
}