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
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@admin.admin",
                    Password = "admin",
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    UserName = "User",
                    Email = "user@user.user",
                    Password = "user",
                    RoleId = 2
                });
        }
    }
}