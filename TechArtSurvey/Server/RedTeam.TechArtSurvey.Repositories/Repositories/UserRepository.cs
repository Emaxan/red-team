using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

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

            return await DbSet.Include(r => r.Role).SingleOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> GetByPrimaryKeyAsync(params object[] key)
        {
            var user = await base.GetByPrimaryKeyAsync(key);

            await Context.Entry(user).Reference(u => u.Role).LoadAsync();

            return user;
        }

        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            var users = await base.GetAllAsync();

            foreach (var user in users)
            {
                await Context.Entry(user).Reference(u => u.Role).LoadAsync();
            }

            return users;
        }
    }
}