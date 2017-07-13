using System;
using System.Collections.Generic;
using System.Linq;
using RedTeam.iTechArtSurvay.DomainModel.Interfaces;

namespace RedTeam.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        /// <summary>
        /// Creates the existing entity.
        /// </summary>
        void Create(TEntity user);

        /// <summary>
        /// Get all entities
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Finds one entity based on its Identifier.
        /// </summary>
        TEntity Get(int id);

        /// <summary>
        /// Updates the existing entity.
        /// </summary>
        void Update(TEntity entity);

        /// <summary>
        /// Delete the given entity.
        /// </summary>
        void Delete(TEntity entity);
    }
}