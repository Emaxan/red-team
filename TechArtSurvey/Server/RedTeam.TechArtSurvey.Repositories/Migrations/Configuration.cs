using System.Data.Entity.Migrations;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.EF;

namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TechArtSurvayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechArtSurvayContext context)
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