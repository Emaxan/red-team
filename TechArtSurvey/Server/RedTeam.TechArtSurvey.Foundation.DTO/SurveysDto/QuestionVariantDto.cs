using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionVariantDto
    {
        public int Number { get; set; }

        [Required]
        public LocalizableStringDto Text { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }

        public string VisibleIf { get; set; }

        public string EnableIf { get; set; }
    }
}