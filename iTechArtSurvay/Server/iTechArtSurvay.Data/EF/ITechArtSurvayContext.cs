using System.Data.Entity;
using iTechArtSurvay.Data.Entities;

namespace iTechArtSurvay.Data.EF
{
    public class ITechArtSurvayContext : DbContext
    {
        public ITechArtSurvayContext(string connectionString) : base(connectionString) 
        {
            Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        static ITechArtSurvayContext()
        {
            Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}