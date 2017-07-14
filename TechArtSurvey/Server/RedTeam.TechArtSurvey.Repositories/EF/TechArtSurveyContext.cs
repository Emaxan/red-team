using System.Data.Entity;
using JetBrains.Annotations;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    [UsedImplicitly]
    public class TechArtSurvayContext : DbContext, IDbContext
    {
        public TechArtSurvayContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}