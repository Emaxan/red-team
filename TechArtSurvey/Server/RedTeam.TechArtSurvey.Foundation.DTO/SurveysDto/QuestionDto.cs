using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        public string Default { get; set; }

        [Required]
        public QuestionTypeDto Type { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [Required]
        public ICollection<QuestionVariantDto> Variants { get; set; }
    }
}