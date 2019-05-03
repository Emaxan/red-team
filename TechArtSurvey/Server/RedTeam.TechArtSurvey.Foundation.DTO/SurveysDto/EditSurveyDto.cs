using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class EditSurveyDto
    {

        public int Id { get; set; }

        [Required]
        public UserDto Author { get; set; }

        [Required(AllowEmptyStrings = false)]
        public LocalizableStringDto Title { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public string Locale { get; set; }

        [Required]
        public bool ShowPrevButton { get; set; }

        [Required]
        public bool ShowCompletedPage { get; set; }

        [Required]
        public bool ShowPageNumbers { get; set; }

        [Required]
        public bool GoNextPageAutomatic { get; set; }

        [Required]
        public bool FirstPageIsStarted { get; set; }

        [Required]
        public bool IsSinglePage { get; set; }

        public string RequiredText { get; set; }

        [Required]
        public int MaxTimeToFinish { get; set; }

        [Required]
        public int MaxTimeToFinishPage { get; set; }

        public string ShowNavigationButtons { get; set; }

        public string QuestionTitleLocation { get; set; }

        public string QuestionErrorLocation { get; set; }

        public string ShowProgressBar { get; set; }

        public string ShowTimerPanel { get; set; }

        public string QuestionsOrder { get; set; }

        public string ShowQuestionNumbers { get; set; }

        public string ShowTimerPanelMode { get; set; }

        [Required]
        public LocalizableStringDto CompletedHtml { get; set; }

        [Required]
        public LocalizableStringDto StartSurveyText { get; set; }

        [Required]
        public LocalizableStringDto PagePrevText { get; set; }

        [Required]
        public LocalizableStringDto PageNextText { get; set; }

        [Required]
        public LocalizableStringDto CompleteText { get; set; }

        [Required]
        public ICollection<Trigger> Triggers { get; set; }

        [Required]
        public ICollection<PageDto> Pages { get; set; }

    }
}