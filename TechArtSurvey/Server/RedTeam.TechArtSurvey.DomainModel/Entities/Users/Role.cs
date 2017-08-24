using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Users
{
    public class Role : IRole<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleTypes RoleType { get; set; }

        public ICollection<User> Users { get; set; }
    }
}