using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Stores
{
    public interface IApplicationRoleStore : IRoleStore<Role, int>
    {

    }
}