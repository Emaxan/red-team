using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> FindRoleByTypeAsync(RoleTypes roleName);
    }
}