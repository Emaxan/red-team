using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class QuestionVariant : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public int TextId { get; set; }

        public LocalizableString Text { get; set; }

        public string Value { get; set; }

        public string VisibleIf { get; set; }

        public string EnableIf { get; set; }

        public double UsageStat { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}