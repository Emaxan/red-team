using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class SurveyResponseDto
    {
        public DateTime PassedDate { get; set; }

        public SurveyVersionResponseDto SurveyVersion { get; set; } 

        public UserDto User { get; set; }

        public ICollection<QuestionAnswerDto> Answers { get; set; }
    }
}