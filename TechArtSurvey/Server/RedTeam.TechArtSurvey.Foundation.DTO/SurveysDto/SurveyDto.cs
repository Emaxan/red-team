using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyDto
    {
        [Required]
        public SurveyParticipantDto Author { get; set; }

        [Required]
        public ICollection<SurveyVersionDto> Versions { get; set; }
    }
}