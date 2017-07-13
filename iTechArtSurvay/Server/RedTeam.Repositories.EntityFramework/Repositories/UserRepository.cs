using System.Data.Entity;
using System.Linq;
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

        public override void Update(User user)
        {
            Context.Users.Attach(user);
            Context.Entry(user).State = EntityState.Modified;
        }

        public override void Delete(User user)
        {
            Context.Users.Remove(user);
        }

        public override User Get(int id)
        {
            return Context.Users.Find(id);
        }

        public override IQueryable<User> GetAll()
        {
            return Context.Users;
        }
    }
}