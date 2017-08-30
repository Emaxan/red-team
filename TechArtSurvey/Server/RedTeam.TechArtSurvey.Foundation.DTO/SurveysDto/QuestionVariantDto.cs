using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class QuestionVariantDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
    }
}