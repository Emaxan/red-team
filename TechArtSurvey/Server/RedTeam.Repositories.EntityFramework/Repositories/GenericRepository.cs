using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

using RedTeam.Logger;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        protected readonly DbContext Context;
        protected readonly ILog Log;

        protected IQueryable<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public GenericRepository(DbContext context, ILog log)
        {
            Context = context;
            Log = log;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Create(TEntity entity)
        {
            Log.Info($"Create entity in database with type {typeof(TEntity).Name}");
            return _dbSet.Add(entity);
        }

        [CanBeNull]
        public virtual async Task<TEntity> GetAsync(int id)
        {
            Log.Info($"Get entity from database with type {typeof(TEntity).Name}");
            var user = await _dbSet.FindAsync(id);
            return user;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            Log.Info($"Get all entities from database with type {typeof(TEntity).Name}");
            var users = await _dbSet.ToListAsync();
            return users;
        }

        public virtual void Update(TEntity entity)
        {
            Log.Info($"Update entity in database with type {typeof(TEntity).Name}");
            _dbSet.AddOrUpdate(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Log.Info($"Delete entity from database with type {typeof(TEntity).Name}");
            _dbSet.Remove(entity);
        }
    }
}