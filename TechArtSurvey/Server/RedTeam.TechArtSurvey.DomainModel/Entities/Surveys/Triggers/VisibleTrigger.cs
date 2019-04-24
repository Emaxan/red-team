using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers
{
    public class VisibleTrigger : Trigger
    {
        public ICollection<Page> Pages { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}