using System.Data.Entity;
using System.Threading.Tasks;

using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context)
            : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            LoggerContext.GetLogger.Info($"Get User with email = {email}");
            var usr = await DbSet.FirstOrDefaultAsync(user => user.Email == email);
            return usr;
        }

        public async Task<User> CheckUserByEmailAsync(string email)
        {
            LoggerContext.GetLogger.Info($"Check User with email = {email}");
            var usr = await DbSet.FirstOrDefaultAsync(user => user.Email == email);
            if (usr != null)
            {
                Detach(usr);
            }
            return usr;
        }
    }
}