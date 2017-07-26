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
    public class ApplicationRoleManager : RoleManager<Role>
    {
        public ApplicationRoleManager(IRoleStore<Role> store)
                    : base(store)
        { }
    }
}
