namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Boolean : Question
    {
        public int LabelId { get; set; }

        public LocalizableString Label { get; set; }
    }
}