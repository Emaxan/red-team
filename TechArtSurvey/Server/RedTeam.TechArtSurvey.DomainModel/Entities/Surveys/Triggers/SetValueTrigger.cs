namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers
{
    public class SetValueTrigger : Trigger
    {
        public string SetToName { get; set; }

        public string SetValue { get; set; }
    }
}