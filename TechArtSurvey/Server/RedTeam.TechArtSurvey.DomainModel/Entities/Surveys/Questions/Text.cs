namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Text : Question
    {
        public int PlaceholderId { get; set; }

        public LocalizableString Placeholder { get; set; }
    }
}