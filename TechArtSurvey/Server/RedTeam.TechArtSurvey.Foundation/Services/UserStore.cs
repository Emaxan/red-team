using Microsoft.AspNet.Identity;
using RedTeam.Logger;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class UserStore : IUserStore<IdentityUser, int>
    {
        protected readonly IDbContext Context;

        private readonly DbSet<IdentityUser> _dbSet;

        public Task CreateAsync(IdentityUser user)
        {
            _dbSet.Add(user);
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(IdentityUser user)
        {
            _dbSet.Remove(user);
            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> FindByIdAsync(int userId)
        {   
            return await _dbSet.FindAsync(userId);
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            return await _dbSet.FirstAsync(u => u.UserName == userName);
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
