using System.Data.Entity.Migrations;

namespace RedTeam.iTechArtSurvay.Repositories.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Users",
                    c => new
                    {
                        Id = c.Int(false, true),
                        Name = c.String(false),
                        Email = c.String(false),
                        Password = c.String(false),
                        RepeatPassword = c.String()
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}