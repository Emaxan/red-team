namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers
{
    public class RunExpressionTrigger : Trigger
    {
        public string SetToName { get; set; }

        public string RunExpression { get; set; }
    }
}