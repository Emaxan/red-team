namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers
{
    public class CopyValueTrigger : Trigger
    {
        public string SetToName { get; set; }

        public string FromName { get; set; }
    }
}