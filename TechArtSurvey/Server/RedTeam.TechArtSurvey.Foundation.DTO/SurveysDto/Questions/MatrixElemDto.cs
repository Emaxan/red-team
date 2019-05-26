using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class MatrixElemDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }

        [Required]
        public string VisibleIf { get; set; }

        [Required]
        public LocalizableStringDto Text { get; set; }
    }
}