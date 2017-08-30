using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class QuestionVariant
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public string Text { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}