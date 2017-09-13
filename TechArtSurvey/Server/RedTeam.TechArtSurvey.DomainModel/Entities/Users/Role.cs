using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.DomainModel.Entities.Users
{
    public class Role : IRole<int>, IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoleTypes RoleType { get; set; }

        public ICollection<User> Users { get; set; }
    }
}