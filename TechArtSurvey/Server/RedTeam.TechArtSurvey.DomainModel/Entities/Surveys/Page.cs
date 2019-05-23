using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Page : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int TitleId { get; set; }

        public LocalizableString Title { get; set; }

        public string VisibleIf { get; set; }

        public string Name { get; set; }

        public bool Visible { get; set; }

        public string QuestionsOrder { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<VisibleTrigger> VisibleTriggers { get; set; }
    }
}