using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class PageDto
    {
        [Required]
        public LocalizableStringDto Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string VisibleIf { get; set; }

        [Required]
        public bool Visible { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string QuestionsOrder { get; set; }

        [Required]
        public ICollection<QuestionDto> Elements { get; set; }
    }
}