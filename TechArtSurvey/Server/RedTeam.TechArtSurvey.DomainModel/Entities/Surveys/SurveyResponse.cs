using System;
using System.Collections.Generic;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyResponse
    {
        public int Id { get; set; }

        public DateTime Passed { get; set; }

        public int SurveyId { get; set; }

        public int SurveyVersion { get; set; }

        public int UserId { get; set; }

        public Survey Survey { get; set; }

        public User User { get; set; }

        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }
}