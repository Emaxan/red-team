using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Users
{
    public class User: IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Survey> Surveys { get; set; }

        public ICollection<SurveyResponse> SurveyResponses { get; set; }
    }
}