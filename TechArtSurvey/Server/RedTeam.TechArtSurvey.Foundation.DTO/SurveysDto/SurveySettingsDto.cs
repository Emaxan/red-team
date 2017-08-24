using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveySettingsDto
    {
        [Required]
        public bool IsAnonymous { get; set; }

        [Required]
        public bool HasQuestionNumbers { get; set; }

        [Required]
        public bool HasPageNumbers { get; set; }

        [Required]
        public bool IsRandomOrdered { get; set; }

        [Required]
        public bool HasRequiredFieldsStars { get; set; }

        [Required]
        public bool HasProgressIndicator { get; set; }
    }
}