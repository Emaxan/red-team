using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class UserRepository : Repository<User, ITechArtSurvayContext>, IUserRepository
    {
        public UserRepository(ITechArtSurvayContext context) : base(context) { }

        public override void Create(User user)
        {
            Context.Users.Add(user);
        }

        public override async Task<User> GetAsync(int id)
        {
            return await Context.Users.FindAsync(id);
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Context.Users.ToListAsync();
        }

        public override void Update(User user)
        {
            Context.Users.Attach(user);
            Context.Entry(user).State = EntityState.Modified;
        }

        public override void Delete(User user)
        {
            Context.Users.Remove(user);
        }
    }
}