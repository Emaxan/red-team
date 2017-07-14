using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.DomainModel.Interfaces;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : class, IDbContext
    {
        protected TContext Context;

        public Repository(IDbContext context)
        {
            Context = context as TContext;
        }

        private IDbSet<TEntity> DbSet => Context.Set<TEntity>();

        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await DbSet.Where(entity => entity.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}