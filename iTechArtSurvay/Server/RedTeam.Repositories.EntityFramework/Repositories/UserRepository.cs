using System.Collections.Generic;
using System.Data.Entity;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ITechArtSurvayContext _context;

        public UserRepository(ITechArtSurvayContext context)
        {
            this._context = context;
        }

        public void Create(User user)
        {
            var user1 = _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if ( user != null )
            {
                _context.Users.Remove(user);
            }
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
    }
}