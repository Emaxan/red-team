using System;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.Repositories.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITechArtSurvayContext _context;
        private bool _disposed;
        private UserRepository _userRepository;

        public UnitOfWork(string connectionString)
        {
            _context = new ITechArtSurvayContext(connectionString);
        }

        public IRepository<User> Users => _userRepository ?? (_userRepository = new UserRepository(_context));

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