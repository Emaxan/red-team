using System.Data.Entity.Migrations;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.EF;

namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TechArtSurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechArtSurveyContext context)
        {
            context.Users.AddOrUpdate(u => u.Email, 
                new User()
                {
                    Name = "Admin",
                    Email = "admin@admin.admin",
                    Password = "admin"
                },
                new User()
                {
                    Name = "User",
                    Email = "user@user.user",
                    Password = "user"
                });
        }
    }
}