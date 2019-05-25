using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionResponseDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}