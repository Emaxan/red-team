namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions
{
    public class MatrixRow
    {
        public int Id { get; set; }

        public int TextId { get; set; }

        public LocalizableString Text { get; set; }

        public string Value { get; set; }

        public string VisibleIf { get; set; }

        public int MatrixId { get; set; }

        public Matrix Matrix { get; set; }
    }
}