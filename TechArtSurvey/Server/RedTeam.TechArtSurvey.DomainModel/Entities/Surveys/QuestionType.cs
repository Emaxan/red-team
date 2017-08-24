using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class QuestionType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public QuestionTypeEnum Type { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
