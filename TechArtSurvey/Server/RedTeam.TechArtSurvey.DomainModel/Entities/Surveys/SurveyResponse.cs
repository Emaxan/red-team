using System;
using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyResponse : IEntity
    {
        public int Id { get; set; }

        public DateTime PassedDate { get; set; }

        public int SurveyVersionId { get; set; }

        public SurveyVersion SurveyVersion { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}