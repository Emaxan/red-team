namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsageStat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionVariant", "UsageStat", c => c.Double(nullable: false));
            AlterColumn("dbo.QuestionAnswer", "Value", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String());
            AlterColumn("dbo.QuestionAnswer", "Value", c => c.String(nullable: false));
            DropColumn("dbo.QuestionVariant", "UsageStat");
        }
    }
}
