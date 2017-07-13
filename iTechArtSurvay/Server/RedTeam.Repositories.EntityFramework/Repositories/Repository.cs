using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RedTeam.iTechArtSurvay.DomainModel.Interfaces;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext: DbContext
    {
        protected TContext Context;

        public Repository(DbContext context)
        {
            Context = context as TContext;
        }

        private IDbSet<TEntity> DbSet => Context.Set<TEntity>();

        public virtual void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if ( disposing )
            {
                if ( Context != null )
                {
                    Context.Dispose();
                    Context = null;
                }
            }
        }
    }
}