using System.Data.Entity;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Repositories.EF
{
    public class ITechArtSurvayContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        static ITechArtSurvayContext()
        {
            //Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public ITechArtSurvayContext() : base("iTechArtSurvayDb")
        {
            
        }

        public ITechArtSurvayContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}