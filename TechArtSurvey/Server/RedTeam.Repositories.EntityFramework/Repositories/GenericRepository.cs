﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        protected readonly DbContext Context;
        protected IQueryable<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public GenericRepository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        [CanBeNull]
        public virtual async Task<TEntity> GetAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);
            return user;
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            var users = await _dbSet.ToListAsync();
            return users;
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;//BUG both variants don't update value
            //_dbSet.Attach(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}