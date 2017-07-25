using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class IdentityRole : IRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
