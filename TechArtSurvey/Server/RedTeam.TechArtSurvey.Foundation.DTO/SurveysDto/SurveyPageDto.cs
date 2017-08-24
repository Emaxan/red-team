using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyPageDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Number { get; set; }

        public ICollection<QuestionDto> Questions { get; set; }
    }
}