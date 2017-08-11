using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        /// <summary>
        ///     Creates the existing entity.
        /// </summary>
        TEntity Create(TEntity user);

        /// <summary>
        ///     Get all entities
        /// </summary>
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        /// <summary>
        ///     Finds one entity based on its Identifier.
        /// </summary>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        ///     Updates the existing entity.
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        ///     Delete the given entity.
        /// </summary>
        void Delete(TEntity entity);
    }
}