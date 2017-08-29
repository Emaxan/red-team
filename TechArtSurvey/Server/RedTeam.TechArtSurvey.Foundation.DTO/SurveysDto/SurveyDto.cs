using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public SurveySettingsDto Settings { get; set; }

        [Required]
        public SurveyAuthorDto Author { get; set; }
        
        [Required]
        public ICollection<SurveyLookupDto> Lookups { get; set; }
    }
}