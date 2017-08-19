using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Managers
{
    [UsedImplicitly]
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IRoleStore<Role, int> store)
            : base(store)
        {

        }
    }
}
