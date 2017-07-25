namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tokens_Delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropTable("dbo.Tokens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Since = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tokens", "UserId");
            AddForeignKey("dbo.Tokens", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
