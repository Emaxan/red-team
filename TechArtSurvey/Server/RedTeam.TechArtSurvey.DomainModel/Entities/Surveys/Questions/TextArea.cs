namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class TextArea : Question
    {
        public int Rows { get; set; }

        public int PlaceholderId { get; set; }
        
        public LocalizableString Placeholder { get; set; }
    }
}