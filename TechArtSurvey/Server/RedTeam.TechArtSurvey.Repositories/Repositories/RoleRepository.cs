using System.Data.Entity;
using System.Threading.Tasks;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IDbContext context)
            : base(context)
        {

        }


        public async Task<Role> FindRoleByTypeAsync(RoleTypes roleType)
        {
            return await DbSet.FirstOrDefaultAsync(r => r.RoleType == roleType);
        }
    }
}