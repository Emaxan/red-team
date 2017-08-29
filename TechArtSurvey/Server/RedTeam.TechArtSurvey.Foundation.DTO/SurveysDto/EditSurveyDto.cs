using System;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class EditSurveyDto : SurveyDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public int Version { get; set; }

        [Required()]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}