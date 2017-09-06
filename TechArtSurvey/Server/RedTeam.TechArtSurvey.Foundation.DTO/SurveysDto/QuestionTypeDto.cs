using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class QuestionTypeDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}