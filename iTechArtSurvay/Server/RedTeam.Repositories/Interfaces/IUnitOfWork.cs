using System;
using System.Threading.Tasks;
using RedTeam.iTechArtSurvay.DomainModel.Interfaces;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable
        where TEntity: class, IEntity
    {
        IRepository<TEntity> Entities { get; }
        Task SaveAsync();
    }
}