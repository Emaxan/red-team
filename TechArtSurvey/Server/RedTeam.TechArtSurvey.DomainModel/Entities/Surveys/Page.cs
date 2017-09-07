using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Page : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Number { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}