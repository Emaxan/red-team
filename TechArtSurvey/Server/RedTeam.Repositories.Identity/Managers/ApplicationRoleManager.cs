using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;

using System.Threading.Tasks;

namespace RedTeam.Repositories.Identity.Managers
{
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store)
                    : base(store)
        {
            

        }

        public async Task<Role> FindByRoleNameAsync(RoleNames roleName)
        {
            int roleNameNum = (Int32)roleName;
            return await FindByNameAsync(roleNameNum.ToString());
        }
    }
}
