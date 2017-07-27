using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Identity.Stores
{
    public class ApplicationRoleStore: IRoleStore<Role,int>
    {
        private IDbContext _db;
        private readonly DbSet<Role> _dbSet;


        protected IQueryable<Role> DbSet
        {
            get { return _dbSet; }
        }
        public ApplicationRoleStore(IDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Role>();
        }

        public async Task CreateAsync(Role role)
        {
            _dbSet.Add(role);
        }

        public async Task DeleteAsync(Role role)
        {
            if (!_dbSet.Local.Contains(role))
            {
                _dbSet.Attach(role);
            }
            _dbSet.Remove(role);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Role> FindByIdAsync(int roleId)
        {
            var role = await _dbSet.FindAsync(roleId);
            return role;
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            Enum.TryParse(roleName, out RoleNames roleType);
            var role = await _dbSet.FirstOrDefaultAsync(r => r.RoleName == roleType);
            return role;
        }

        public async Task UpdateAsync(Role role)
        {
            if (!_dbSet.Local.Contains(role))
            {
                _db.Entry(role).State = EntityState.Modified;
            }
        }
    }
}
