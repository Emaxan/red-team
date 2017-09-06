﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class SurveyVersionDto
    {
        public int Version { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public SurveySettingsDto Settings { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public ICollection<SurveyPageDto> Pages { get; set; }
    }
}