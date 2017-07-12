using System.Collections.Generic;

namespace iTechArtSurvay.Infrastructure.Repositores
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}