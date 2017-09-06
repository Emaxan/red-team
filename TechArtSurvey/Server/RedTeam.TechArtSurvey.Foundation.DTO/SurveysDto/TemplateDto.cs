using System.Collections.Generic;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class TemplateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<SurveyPageDto> Pages { get; set; }
    }
}