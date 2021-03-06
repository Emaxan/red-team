﻿using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions
{
    [UsedImplicitly]
    public class BooleanDto : QuestionDto
    {
        [Required]
        public LocalizableStringDto Label { get; set; }
    }
}