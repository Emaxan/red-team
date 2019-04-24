namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class Dropdown : Question
    {
        public bool HasOther { get; set; }

        public int OtherTextId { get; set; }

        public LocalizableString OtherText { get; set; }

        public int OptionsCaptionId { get; set; }

        public LocalizableString OptionsCaption { get; set; }

        public string ChoicesOrder { get; set; }
    }
}