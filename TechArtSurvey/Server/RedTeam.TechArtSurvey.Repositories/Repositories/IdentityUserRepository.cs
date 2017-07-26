using System.Data.Entity;
using System.Threading.Tasks;

using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class IdentityUserRepository : Repository<IdentityUser>, IIdentityUserRepository
    {
        public IdentityUserRepository(IDbContext context)
            : base(context)
        {
        }


        public async Task<IdentityUser> GetUserByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");
            return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}