using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using JetBrains.Annotations;

using log4net;

using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    [UsedImplicitly]
    public class GenericUnitOfWork : IGenericUnitOfWork
    {
        private bool _disposed;
        private readonly Dictionary<Type, object> _repositoriesDictionary;

        protected readonly DbContext Context;
        protected readonly ILog Log;

        [UsedImplicitly]
        public GenericUnitOfWork(DbContext context, ILog log)
        {
            Context = context;
            Log = log;
            _repositoriesDictionary = new Dictionary<Type, object>();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof( TEntity );

            if ( !_repositoriesDictionary.ContainsKey(type) )
            {
                _repositoriesDictionary.Add(type, new GenericRepository<TEntity>(Context, Log));
            }

            return (IGenericRepository<TEntity>) _repositoriesDictionary[typeof( TEntity )];
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
                if ( disposing )
                    Context.Dispose();
                _disposed = true;
            }
        }
    }
}