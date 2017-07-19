using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using JetBrains.Annotations;

using RedTeam.Logger;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly IDbContext Context;

        private readonly DbSet<TEntity> _dbSet;


        protected IQueryable<TEntity> DbSet
        {
            get { return _dbSet; }
        }


        public Repository(IDbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }


        public virtual TEntity Create(TEntity entity)
        {
            LoggerContext.GetLogger.Info($"Create entity in database with type {typeof(TEntity).Name}");
            return _dbSet.Add(entity);
        }

        [CanBeNull]
        public virtual async Task<TEntity> GetAsync(int id)
        {
            LoggerContext.GetLogger.Info($"Get entity from database with id {id}");
            var user = await _dbSet.FindAsync(id);
            return user;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            LoggerContext.GetLogger.Info($"Get all entities from database with type {typeof(TEntity).Name}");
            var users = await _dbSet.ToListAsync();
            return users;
        }

        public virtual void Update(TEntity entity)
        {
            LoggerContext.GetLogger.Info($"Update entity in database with type {typeof(TEntity).Name}");
            if (!_dbSet.Local.Contains(entity))
            {
                Detach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            LoggerContext.GetLogger.Info($"Delete entity from database with type {typeof(TEntity).Name}");
            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Detach(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
    }
}