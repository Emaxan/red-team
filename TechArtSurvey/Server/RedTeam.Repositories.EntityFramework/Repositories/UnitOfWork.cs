using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    [UsedImplicitly]
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDbContext Context;

        private bool _disposed;
        private readonly Dictionary<Type, object> _repositoriesDictionary;


        [UsedImplicitly]
        public UnitOfWork(IDbContext context)
        {
            Context = context;
            _repositoriesDictionary = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof( TEntity );

            if ( !_repositoriesDictionary.ContainsKey(type) )
            {
                _repositoriesDictionary.Add(type, new Repository<TEntity>(Context));
            }

            return (IRepository<TEntity>) _repositoriesDictionary[typeof( TEntity )];
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if ( !_disposed )
            {
                return;
            }

            Context.Dispose();
            _disposed = true;
        }
    }
}