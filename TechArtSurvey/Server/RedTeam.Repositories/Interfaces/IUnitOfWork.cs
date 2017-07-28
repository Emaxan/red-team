using System;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task SaveAsync();
    }
}