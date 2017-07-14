using System.Data.Entity.Migrations;
using RedTeam.iTechArtSurvay.DomainModel.Entities;
using RedTeam.iTechArtSurvay.Repositories.EF;

namespace RedTeam.iTechArtSurvay.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ITechArtSurvayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITechArtSurvayContext context)
        {
            context.Users.Add(new User
            {
                Name = "Admin",
                Email = "admin@admin.admin",
                Password = "admin"
            });
            context.Users.Add(new User
            {
                Name = "User",
                Email = "user@user.user",
                Password = "user"
            });

            context.SaveChanges();
        }
    }
}