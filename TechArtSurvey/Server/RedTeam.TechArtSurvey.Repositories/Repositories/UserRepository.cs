using System.Data.Entity;
using System.Threading.Tasks;

using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var usr = await DbSet.FirstOrDefaultAsync(user => user.Email == email);
            return usr;
        }
    }
}