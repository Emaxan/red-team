namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumbers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Page", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.QuestionVariant", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionVariant", "Number");
            DropColumn("dbo.Question", "Number");
            DropColumn("dbo.Page", "Number");
        }
    }
}
