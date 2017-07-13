namespace RedTeam.iTechArtSurvay.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RepeatPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RepeatPassword", c => c.String());
        }
    }
}
