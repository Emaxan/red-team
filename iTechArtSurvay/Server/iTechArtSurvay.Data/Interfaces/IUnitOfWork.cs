using System;
using iTechArtSurvay.Data.Entities;

namespace iTechArtSurvay.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        void Save();
    }
}