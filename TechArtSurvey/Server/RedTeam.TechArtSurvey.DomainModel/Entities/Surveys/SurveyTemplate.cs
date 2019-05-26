using System;
using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class SurveyTemplate : IEntity
    {
        public int Id { get; set; }

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

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int DescriptionId { get; set; }

        public LocalizableString Description { get; set; }

        public ICollection<Trigger> Triggers { get; set; }

        public ICollection<TemplatePage> Pages { get; set; }
    }
}