namespace iTechArtSurvay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RepeatPassword", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "RepeatPassword", c => c.String(nullable: false));
        }
    }
}
