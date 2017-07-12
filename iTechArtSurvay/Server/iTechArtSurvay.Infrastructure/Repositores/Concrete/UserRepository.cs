using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using iTechArtSurvay.Data;
using iTechArtSurvay.Domain.Models;
using iTechArtSurvay.Infrastructure.Repositores.Abstract;

namespace iTechArtSurvay.Infrastructure.Repositores.Concrete
{
    public class UserRepository : IUserRepository
    {
        private ITechArtSurvayContext context = new ITechArtSurvayContext();

        public void CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }
    }
}