using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.DomainModel.Entities
{
    public class Role : IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        string IRole<string>.Id => throw new NotImplementedException();
    }
}
