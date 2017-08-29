using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        [Required]
        public QuestionTypeDto Type { get; set; }

        [Required]
        public bool IsRequired { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string MetaInfo { get; set; }
    }
}