using System;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.DomainModel.Interfaces;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ITechArtSurvayContext _context;
        private bool _disposed;
        private IRepository<TEntity> _entityRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new ITechArtSurvayContext(connectionString);
        }

        public IRepository<TEntity> Entities => _entityRepository ??
                                                (_entityRepository = new Repository<TEntity, IDbContext>(_context));

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();
                _disposed = true;
            }
        }
    }
}