using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class TemplateDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TemplateLookupDto> Lookups { get; set; }
    }
}