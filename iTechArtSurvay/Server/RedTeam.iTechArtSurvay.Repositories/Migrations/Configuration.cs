using RedTeam.iTechArtSurvay.DomainModel.Entities;

namespace RedTeam.iTechArtSurvay.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RedTeam.iTechArtSurvay.Repositories.EF.ITechArtSurvayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RedTeam.iTechArtSurvay.Repositories.EF.ITechArtSurvayContext context)
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
