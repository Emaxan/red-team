using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class RadioGroupDto : QuestionDto
    {
        [Required]
        public LocalizableStringDto OtherText { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ColCount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ChoicesOrder { get; set; }

        [Required]
        public bool HasOther { get; set; }
    }
}