using System;
using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyVersion : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int TitleId { get; set; }

        public LocalizableString Title { get; set; }

        public int CompletedHtmlId { get; set; }

        public LocalizableString CompletedHtml { get; set; }

        public int StartSurveyTextId { get; set; }

        public LocalizableString StartSurveyText { get; set; }

        public int PagePrevTextId { get; set; }

        public LocalizableString PagePrevText { get; set; }

        public int PageNextTextId { get; set; }

        public LocalizableString PageNextText { get; set; }

        public int CompleteTextId { get; set; }

        public LocalizableString CompleteText { get; set; }

        public SurveySettings Settings { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int SurveyId { get; set; }

        public Survey Survey { get; set; }

        public ICollection<Trigger> Triggers { get; set; }

        public ICollection<SurveyResponse> Responses { get; set; }

        public ICollection<SurveyPage> Pages { get; set; }
    }
}