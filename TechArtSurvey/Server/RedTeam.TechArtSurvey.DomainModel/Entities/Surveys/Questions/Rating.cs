namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Rating : Question
    {
        public int Rows { get; set; }

        public int MinRateDescriptionId { get; set; }
        
        public LocalizableString MinRateDescription { get; set; }

        public int MaxRateDescriptionId { get; set; }
        
        public LocalizableString MaxRateDescription { get; set; }
    }
}