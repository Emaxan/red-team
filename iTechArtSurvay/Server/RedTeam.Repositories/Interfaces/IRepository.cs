using System.Collections.Generic;
using RedTeam.iTechArtSurvay.DomainModel.Entities;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T user);
        void Update(T user);
        void Delete(int id);
        User Get(int id);
        IEnumerable<T> GetAll();
    }
}