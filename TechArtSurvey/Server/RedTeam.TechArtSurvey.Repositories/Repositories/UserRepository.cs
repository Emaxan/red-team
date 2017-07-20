using System.Data.Entity;
using System.Threading.Tasks;

using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDbContext context)
            : base(context)
        {
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");
            return await DbSet.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}