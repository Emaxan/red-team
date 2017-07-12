using System.Collections.Generic;
using System.Data.Entity;
using iTechArtSurvay.Data.EF;
using iTechArtSurvay.Data.Entities;
using iTechArtSurvay.Data.Interfaces;

namespace iTechArtSurvay.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ITechArtSurvayContext context;

        public UserRepository(ITechArtSurvayContext context)
        {
            this.context = context;
        }

        public void Create(User user)
        {
            var user1 = context.Users.Add(user);//TODO Test it, user don't add via post method
        }

        public void Update(User user)
        {
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            if ( user != null )
                context.Users.Remove(user);
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
    }
}