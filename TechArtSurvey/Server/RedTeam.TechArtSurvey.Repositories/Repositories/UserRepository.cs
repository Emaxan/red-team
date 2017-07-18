using System.Data.Entity;
using System.Threading.Tasks;

using log4net;

using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context, ILog log)
            : base(context, log)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            Log.Info($"Get User with email = {email}");
            var usr = await DbSet.FirstOrDefaultAsync(user => user.Email == email);
            return usr;
        }
    }
}