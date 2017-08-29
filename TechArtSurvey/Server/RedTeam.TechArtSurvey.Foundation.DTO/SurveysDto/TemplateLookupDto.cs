namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class TemplateLookupDto
    {
        public int PageId { get; set; }

        public SurveyPageDto Page { get; set; }

        public int TemplateId { get; set; }

        public TemplateDto Template { get; set; }
    }
}