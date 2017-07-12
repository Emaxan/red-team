using System.Data.Entity;
using iTechArtSurvay.Domain.Models;

namespace iTechArtSurvay.Data
{
    public class ITechArtSurvayInitializer : DropCreateDatabaseAlways<ITechArtSurvayContext>
    {
        protected override void Seed(ITechArtSurvayContext context)
        {
            context.Users.Add(new User() { Name = "Admin", Email = "admin@admin.admin", Password = "admin" });
            context.Users.Add(new User() { Name = "User", Email = "user@user.user", Password = "user" });

            base.Seed(context);
        }
    }
}