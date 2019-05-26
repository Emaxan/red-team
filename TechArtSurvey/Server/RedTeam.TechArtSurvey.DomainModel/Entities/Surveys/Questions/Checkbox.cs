namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Checkbox : Question
    {
        public bool HasOther { get; set; }

        public int ColCount { get; set; }

        public string ChoicesOrder { get; set; }
    }
}