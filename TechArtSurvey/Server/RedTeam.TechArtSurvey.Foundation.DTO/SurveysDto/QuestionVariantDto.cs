using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionVariantDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
    }
}