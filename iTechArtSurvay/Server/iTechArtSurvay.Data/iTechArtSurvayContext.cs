using System.Data.Entity;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.Data
{
    public class ITechArtSurvayContext : DbContext
    {
        public ITechArtSurvayContext() : base("iTechArtSurvayDb")
        {
            Database.SetInitializer(new ITechArtSurvayInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}