using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionTypeDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}