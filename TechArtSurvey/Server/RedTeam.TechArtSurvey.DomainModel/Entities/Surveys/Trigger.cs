namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Trigger
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Expression { get; set; }

        public int SurveyVersionId { get; set; }
    }
}