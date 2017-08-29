using System;
using System.Collections.Generic;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyResponseDto
    {
        public int Id { get; set; }

        public DateTime PassedDate { get; set; }

        public int SurveyId { get; set; }

        public int SurveyVersion { get; set; }

        public SurveyDto Survey { get; set; }

        public int UserId { get; set; }

        public UserDto User { get; set; }

        public ICollection<QuestionAnswerDto> Answers { get; set; }
    }
}