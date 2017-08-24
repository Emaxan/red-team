using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyLookupDto
    {
        [Required]
        public SurveyPageDto SurveyPage { get; set; }
    }
}