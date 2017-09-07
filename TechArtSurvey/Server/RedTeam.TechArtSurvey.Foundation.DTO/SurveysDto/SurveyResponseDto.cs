using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class SurveyResponseDto
    {
        public int Id { get; set; }

        public DateTime PassedDate { get; set; }

        public SurveyVersionDto SurveyVersion { get; set; }

        public UserDto User { get; set; }

        public ICollection<QuestionAnswerDto> Answers { get; set; }
    }
}