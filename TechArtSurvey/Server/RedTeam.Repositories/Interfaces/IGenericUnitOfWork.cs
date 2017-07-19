using System;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IGenericUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task SaveAsync();
    }
}