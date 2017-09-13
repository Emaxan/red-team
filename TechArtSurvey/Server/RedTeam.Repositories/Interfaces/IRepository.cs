using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        /// <summary>
        ///     Creates the existing entity.
        /// </summary>
        TEntity Create(TEntity entity);

        /// <summary>
        ///     Get all entities
        /// </summary>
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Finds one entity based on its Identifier.
        /// </summary>
        Task<TEntity> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        ///     Updates the existing entity.
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        ///     Delete the given entity.
        /// </summary>
        void Delete(TEntity entity);

        /// <summary>
        ///     Delete range of entities.
        /// </summary>
        void DeleteRange(IReadOnlyCollection<TEntity> entities);
    }
}