using System.Data.Entity;
using RedTeam.iTechArtSurvay.DomainModel.Entities;

namespace RedTeam.iTechArtSurvay.Repositories.EF
{
    public class ITechArtSurvayContext : DbContext
    {
        static ITechArtSurvayContext()
        {
            Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public ITechArtSurvayContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}