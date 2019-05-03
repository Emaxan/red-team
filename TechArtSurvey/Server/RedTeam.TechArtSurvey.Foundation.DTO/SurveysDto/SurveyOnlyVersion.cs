using System.Collections.Generic;
using System.Linq;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    public class SurveyOnlyVersion
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public SurveyVersion Version { get; set; }

        public Survey ToSurvey()
        {
            return new Survey
            {
                AuthorId = AuthorId,
                Author = Author,
                Id = Id,
                Versions = new List<SurveyVersion>{ Version }
            };
        }

        public static SurveyOnlyVersion FromSurveyByVersion(Survey survey, int version = 1)
        {
            return new SurveyOnlyVersion
            {
                AuthorId = survey.AuthorId,
                Author = survey.Author,
                Id = survey.Id,
                Version = survey.Versions.FirstOrDefault(sv => sv.Number == version)
            };
        }
    }
}