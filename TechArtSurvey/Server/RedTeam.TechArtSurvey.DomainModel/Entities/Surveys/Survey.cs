﻿using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Survey
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public string Title { get; set; }

        public int SettingsId { get; set; }

        public SurveySettings Settings { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public ICollection<SurveyResponse> Response { get; set; }

        public ICollection<SurveyLookup> Lookups { get; set; }
    }
}