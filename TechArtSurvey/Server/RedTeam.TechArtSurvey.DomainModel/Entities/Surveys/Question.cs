using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Question
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        public string Title { get; set; }

        public int QuestionNumber { get; set; }

        public int QuestionTypeId { get; set; }

        public bool IsRequired { get; set; }

        public string MetaInfo { get; set; }

        public SurveyPage Page { get; set; }

        public QuestionType QuestionType { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}