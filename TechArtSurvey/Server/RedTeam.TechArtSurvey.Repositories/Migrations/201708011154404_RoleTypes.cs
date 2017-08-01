namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Name", c => c.String());
            AddColumn("dbo.Roles", "RoleType", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "RoleName", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "RoleType");
            DropColumn("dbo.Roles", "Name");
        }
    }
}
