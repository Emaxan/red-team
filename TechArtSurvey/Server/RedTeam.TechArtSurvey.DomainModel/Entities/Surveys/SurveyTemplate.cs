using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyTemplate : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<TemplatePage> Pages { get; set; }
    }
}
