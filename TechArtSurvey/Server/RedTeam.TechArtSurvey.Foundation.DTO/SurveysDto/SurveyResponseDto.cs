using System;
using System.Collections.Generic;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyResponseDto
    {
        public int Id { get; set; }

        public DateTime PassedDate { get; set; }

        public SurveyVersionDto SurveyVersion { get; set; }

        public SurveyParticipantDto User { get; set; }

        public ICollection<QuestionAnswerDto> Answers { get; set; }
    }
}