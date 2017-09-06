using System.Data.Entity.Migrations;

namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    
    public partial class requiredRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Int());
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id");
        }
    }
}
