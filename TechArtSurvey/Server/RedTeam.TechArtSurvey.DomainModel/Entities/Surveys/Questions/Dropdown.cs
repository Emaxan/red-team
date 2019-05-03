namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Dropdown : Question
    {
        public bool HasOther { get; set; }

        public string ChoicesOrder { get; set; }
    }
}