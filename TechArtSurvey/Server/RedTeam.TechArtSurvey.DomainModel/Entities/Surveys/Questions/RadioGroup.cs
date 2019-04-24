namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class RadioGroup : Question
    {
        public bool HasOther { get; set; }

        public int OtherTextId { get; set; }

        public LocalizableString OtherText { get; set; }

        public string ChoicesOrder { get; set; }
    }
}