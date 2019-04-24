namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class DatePicker : Question
    {
        public int PlaceholderId { get; set; }

        public LocalizableString Placeholder { get; set; }
    }
}