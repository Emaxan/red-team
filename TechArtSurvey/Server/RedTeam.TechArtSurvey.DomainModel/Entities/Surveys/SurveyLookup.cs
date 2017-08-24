﻿using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyLookup
    {
        public int PageId { get; set; }
            
        public int SurveyId { get; set; }

        public int SurveyVersion { get; set; }

        public Survey Survey { get; set; }

        public SurveyPage SurveyPage { get; set; }
    }
}