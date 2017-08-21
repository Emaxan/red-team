using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Managers
{
    [UsedImplicitly]
    public class ApplicationRoleManager : RoleManager<Role, int>
    {
        public ApplicationRoleManager(IApplicationRoleStore store)
            : base(store)
        {

        }
    }
}
