using System;
using System.Collections.Generic;
using iTechArtSurvay.Data;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.Infrastructure.Repositores.Implemenations
{
    public class UserRepository : IRepository<User>
    {
        private ITechArtSurvayContext context = new ITechArtSurvayContext();

        public void Add(User entity)
        {
            context.Users.Add(entity);
            context.SaveChanges();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }
    }
}