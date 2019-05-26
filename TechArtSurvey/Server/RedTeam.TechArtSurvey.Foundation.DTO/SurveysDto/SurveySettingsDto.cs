using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class SurveySettingsDto
    {
        public string Locale { get; set; }

        public bool ShowPrevButton { get; set; }

        public bool ShowCompletedPage { get; set; }

        public bool ShowPageNumbers { get; set; }

        public bool GoNextPageAutomatic { get; set; }

        public bool FirstPageIsStarted { get; set; }

        public bool IsSinglePage { get; set; }

        public string RequiredText { get; set; }

        public int MaxTimeToFinish { get; set; }

        public int MaxTimeToFinishPage { get; set; }

        public string ShowNavigationButtons { get; set; }

        public string QuestionTitleLocation { get; set; }

        public string QuestionErrorLocation { get; set; }

        public string ShowProgressBar { get; set; }

        public string ShowTimerPanel { get; set; }

        public string QuestionsOrder { get; set; }

        public string ShowQuestionNumbers { get; set; }

        public string ShowTimerPanelMode { get; set; }
    }
}