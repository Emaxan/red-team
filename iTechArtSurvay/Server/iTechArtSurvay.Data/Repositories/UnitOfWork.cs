using System;
using iTechArtSurvay.Data.EF;
using iTechArtSurvay.Data.Entities;
using iTechArtSurvay.Data.Interfaces;

namespace iTechArtSurvay.Data.Repositories
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

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if ( _disposed ) return;
            if ( disposing ) _context.Dispose();
            _disposed = true;
        }
    }
}