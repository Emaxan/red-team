using Microsoft.AspNet.Identity;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Identity.Stores
{
    public class ApplicationUserstore : IUserStore<User>
    {
        private IDbContext _db;
        private readonly DbSet<User> _dbSet;

        protected IQueryable<User> DbSet
        {
            get { return _dbSet; }
        }

        public ApplicationUserstore(IDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<User>();
        }

        public async Task CreateAsync(User user)
        {
            _dbSet.Add(user);
        }

        public async Task DeleteAsync(User user)
        {
            if (!_dbSet.Local.Contains(user))
            {
                _dbSet.Attach(user);
            }
            _dbSet.Remove(user);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            var user = await _dbSet.FindAsync(Convert.ToInt32(userId));
            return user;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _dbSet.FirstAsync(u => u.Email == email);
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            if (!_dbSet.Local.Contains(user))
            {
                _db.Entry(user).State = EntityState.Modified;
            }
        }
    }
}
