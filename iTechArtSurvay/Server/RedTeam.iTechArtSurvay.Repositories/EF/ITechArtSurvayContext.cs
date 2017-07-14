using System.Data.Entity;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.Repositories.Interfaces;
using JetBrains.Annotations;

namespace RedTeam.iTechArtSurvay.Repositories.EF
{
    [UsedImplicitly]
    public class ITechArtSurvayContext : DbContext, IDbContext
    {
        public ITechArtSurvayContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}