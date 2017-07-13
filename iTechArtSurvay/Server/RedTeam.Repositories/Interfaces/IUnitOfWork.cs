using System;
using RedTeam.iTechArtSurvay.DomainModel.Entities;

namespace RedTeam.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        void Save();
    }
}