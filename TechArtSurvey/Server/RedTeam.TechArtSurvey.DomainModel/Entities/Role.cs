using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class Role : IRole<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleTypes RoleType { get; set; }

        public ICollection<User> Users { get; set; }
    }
}