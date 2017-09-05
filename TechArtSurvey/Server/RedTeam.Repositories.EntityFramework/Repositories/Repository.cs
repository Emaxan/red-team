using RedTeam.Logger;
using RedTeam.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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
            LoggerContext.Logger.Info($"Create entity in database with type {typeof(TEntity).Name}");

            return _dbSet.Add(entity);
        }
        
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get entity from database with id {id}");
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            LoggerContext.Logger.Info($"Get all entities from database with type {typeof(TEntity).Name}");
            var entities = await _dbSet.ToListAsync();

            return entities;
        }

        public virtual void Update(TEntity entity)
        {
            LoggerContext.Logger.Info($"Update entity in database with type {typeof(TEntity).Name}");
            if (!_dbSet.Local.Contains(entity))
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            LoggerContext.Logger.Info($"Delete entity from database with type {typeof(TEntity).Name}");
            if (!_dbSet.Local.Contains(entity))
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IReadOnlyCollection<TEntity> entities)
        {
            LoggerContext.Logger.Info($"Delete {entities.Count} entity from database with type {typeof(TEntity).Name}");
            foreach (var entity in entities)
            {
                if (!_dbSet.Local.Contains(entity))
                {
                    _dbSet.Attach(entity);
                }
            }
            _dbSet.RemoveRange(entities);
        }
    }
}