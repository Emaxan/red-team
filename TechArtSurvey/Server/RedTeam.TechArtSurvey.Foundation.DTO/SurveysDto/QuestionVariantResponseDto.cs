using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionVariantResponseDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Value { get; set; }
    }
}