using JetBrains.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionDto
    {
        [Required]
        public LocalizableStringDto Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [Required(AllowEmptyStrings = false)]
        public QuestionTypeDto Type { get; set; }

        public string EnableIf { get; set; }

        public string VisibleIf { get; set; }

        [Required]
        public bool Visible { get; set; }

        [Required]
        public bool StartWithNewLine { get; set; }

        public ICollection<QuestionVariantDto> Choices { get; set; }
    }
}