using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Repositories.Repositories
{
    public class UserRepository : Repository<User, ITechArtSurvayContext>, IUserRepository
    {
        public UserRepository(ITechArtSurvayContext context)
            : base(context)
        {
        }

        public override void Create(User user)
        {
            Context.Users.Add(user);
        }

        [CanBeNull]
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