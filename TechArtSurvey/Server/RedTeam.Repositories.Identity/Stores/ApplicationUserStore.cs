﻿using Microsoft.AspNet.Identity;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace RedTeam.Repositories.Identity.Stores
{
    public class ApplicationUserstore : IUserStore<User, int>, IUserEmailStore<User, int>
    {
        private IDbContext _db;
        private readonly DbSet<User> _dbSet;
        private readonly DbSet<Role> _roles;
        protected IQueryable<User> DbSet
        {
            get { return _dbSet; }
        }

        public ApplicationUserstore(IDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<User>();
            _roles = db.Set<Role>();
        }

        public async Task CreateAsync(User user)
        {
            var result = _dbSet.Add(user);
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

        public async Task<User> FindByIdAsync(int userId)
        {
            var user = await _dbSet.FindAsync(Convert.ToInt32(userId));
            return user;
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return new User();
        }

        public async Task<User> FindByEmailAsync(string email)
        {

            var user =  _dbSet.Where(u => u.Email == email).Include(r => r.Role).FirstOrDefault();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            if (!_dbSet.Local.Contains(user))
            {
                _db.Entry(user).State = EntityState.Modified;
            }
        }

        public async Task SetEmailAsync(User user, string email)
        {
        }

        public async Task<string> GetEmailAsync(User user)
        {
            return user.Email;
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed)
        {

        }
    }
}
