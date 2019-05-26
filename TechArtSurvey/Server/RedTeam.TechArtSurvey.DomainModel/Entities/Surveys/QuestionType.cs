using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class QuestionType : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public QuestionTypes Type { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}