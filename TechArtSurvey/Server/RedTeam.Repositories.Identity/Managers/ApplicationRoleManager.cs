using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Identity.Managers
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store)
                    : base(store)
        { }
    }
}
