using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Question
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public SurveyPage Page { get; set; }

        public string Title { get; set; }

        public int Number { get; set; }

        public int TypeId { get; set; }

        public QuestionType Type { get; set; }

        public bool IsRequired { get; set; }

        public string MetaInfo { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}