using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class SurveyVersionHeaderDto
    {
        public int Number { get; set; }

        [Required(AllowEmptyStrings = false)]
        public LocalizableStringDto Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Locale { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}