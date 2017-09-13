using System;
using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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


        public async Task<User> GetUserByEmailAsync(string email, params Expression<Func<User, object>>[] includes)
        {
            LoggerContext.Logger.Info($"Get User with email = {email}");

            return await includes.Aggregate(DbSet, (cur, include) => cur.Include(include))
                                 .SingleOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> GetByIdAsync(int id, params Expression<Func<User, object>>[] includes)
        {
            var user = await base.GetByIdAsync(id, includes);
            
            return user;
        }
    }
}