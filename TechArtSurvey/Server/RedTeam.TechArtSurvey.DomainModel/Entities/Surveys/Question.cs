using System.Collections.Generic;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Surveys
{
    public class Question : IEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int TitleId { get; set; }

        public LocalizableString Title { get; set; }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        public int PageId { get; set; }

        public Page Page { get; set; }

        public int TypeId { get; set; }

        public QuestionType Type { get; set; }

        public string EnableIf { get; set; }

        public string VisibleIf { get; set; }

        public bool Visible { get; set; }

        public bool StartWithNewLine { get; set; }

        public ICollection<QuestionVariant> Choices { get; set; }

        public ICollection<QuestionAnswer> Answers { get; set; }

        public ICollection<VisibleTrigger> VisibleTriggers { get; set; }

        // From other questions

        public int PlaceholderId { get; set; }

        public LocalizableString Placeholder { get; set; }

        public int MinRateDescriptionId { get; set; }

        public LocalizableString MinRateDescription { get; set; }

        public int MaxRateDescriptionId { get; set; }

        public LocalizableString MaxRateDescription { get; set; }

        public int OptionsCaptionId { get; set; }

        public LocalizableString OptionsCaption { get; set; }

        public ICollection<MatrixRow> MatrixRows { get; set; }

        public ICollection<MatrixCol> MatrixCols { get; set; }
    }
}