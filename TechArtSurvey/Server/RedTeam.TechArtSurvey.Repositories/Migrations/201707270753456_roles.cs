namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserName");
        }
    }
}
