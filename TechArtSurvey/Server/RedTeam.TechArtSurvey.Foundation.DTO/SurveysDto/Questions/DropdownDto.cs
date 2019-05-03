using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class DropdownDto : QuestionDto
    {
        [Required]
        public bool HasOther { get; set; }

        [Required]
        public LocalizableStringDto OptionsCaption { get; set; }

        [Required]
        public LocalizableStringDto OtherText { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ChoicesOrder { get; set; }
    }
}