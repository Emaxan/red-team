using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class User: IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public Role Role { get; set; }

    }
}