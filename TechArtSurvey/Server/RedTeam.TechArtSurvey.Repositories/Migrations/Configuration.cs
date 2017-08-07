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
            context.Roles.AddOrUpdate(r => r.RoleType,
               new Role()
               {
                   Id = 1,
                   Name = "Admin",
                   RoleType = RoleTypes.Admin
               },
               new Role()
               {
                   Id = 2,
                   Name = "User",
                   RoleType = RoleTypes.User
               });

            context.Users.AddOrUpdate(u => u.Email,
                new User()
                {
                    Id = 1,
                    UserName = "Admin",
                    Email = "admin@admin.admin",
                    Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    UserName = "User",
                    Email = "user@user.user",
                    Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                    RoleId = 2
                });
        }
    }
}