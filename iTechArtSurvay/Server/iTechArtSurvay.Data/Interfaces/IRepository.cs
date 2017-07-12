using System.Collections.Generic;
using iTechArtSurvay.Data.Entities;

namespace iTechArtSurvay.Data.Interfaces
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