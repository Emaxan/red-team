using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Stores
{
    public interface IApplicationRoleStore : IRoleStore<Role, int>
    {

    }
}