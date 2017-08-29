namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurveys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionAnswer",
                c => new
                    {
                        SurveyResponseId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyResponseId, t.QuestionId })
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.SurveyResponse", t => t.SurveyResponseId)
                .Index(t => t.SurveyResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        MetaInfo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyPage", t => t.PageId)
                .ForeignKey("dbo.QuestionType", t => t.TypeId)
                .Index(t => t.PageId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.SurveyPage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyLookup",
                c => new
                    {
                        SurveyId = c.Int(nullable: false),
                        PageId = c.Int(nullable: false),
                        SurveyVersion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyId, t.PageId, t.SurveyVersion })
                .ForeignKey("dbo.SurveyPage", t => t.PageId)
                .ForeignKey("dbo.Survey", t => new { t.SurveyId, t.SurveyVersion })
                .Index(t => new { t.SurveyId, t.SurveyVersion })
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        SettingsId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Version })
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.SurveySettings", t => t.SettingsId)
                .Index(t => t.SettingsId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.SurveyResponse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassedDate = c.DateTime(nullable: false),
                        SurveyId = c.Int(nullable: false),
                        SurveyVersion = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Survey", t => new { t.SurveyId, t.SurveyVersion })
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => new { t.SurveyId, t.SurveyVersion })
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SurveySettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAnonymous = c.Boolean(nullable: false),
                        HasQuestionNumbers = c.Boolean(nullable: false),
                        HasPageNumbers = c.Boolean(nullable: false),
                        IsRandomOrdered = c.Boolean(nullable: false),
                        HasRequiredFieldsStars = c.Boolean(nullable: false),
                        HasProgressIndicator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateLookup",
                c => new
                    {
                        TemplateId = c.Int(nullable: false),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TemplateId, t.PageId })
                .ForeignKey("dbo.Template", t => t.TemplateId)
                .ForeignKey("dbo.SurveyPage", t => t.PageId)
                .Index(t => t.TemplateId)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswer", "SurveyResponseId", "dbo.SurveyResponse");
            DropForeignKey("dbo.QuestionAnswer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "TypeId", "dbo.QuestionType");
            DropForeignKey("dbo.Question", "PageId", "dbo.SurveyPage");
            DropForeignKey("dbo.TemplateLookup", "PageId", "dbo.SurveyPage");
            DropForeignKey("dbo.TemplateLookup", "TemplateId", "dbo.Template");
            DropForeignKey("dbo.SurveyLookup", new[] { "SurveyId", "SurveyVersion" }, "dbo.Survey");
            DropForeignKey("dbo.Survey", "SettingsId", "dbo.SurveySettings");
            DropForeignKey("dbo.Survey", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.SurveyResponse", "UserId", "dbo.Users");
            DropForeignKey("dbo.SurveyResponse", new[] { "SurveyId", "SurveyVersion" }, "dbo.Survey");
            DropForeignKey("dbo.SurveyLookup", "PageId", "dbo.SurveyPage");
            DropIndex("dbo.TemplateLookup", new[] { "PageId" });
            DropIndex("dbo.TemplateLookup", new[] { "TemplateId" });
            DropIndex("dbo.SurveyResponse", new[] { "UserId" });
            DropIndex("dbo.SurveyResponse", new[] { "SurveyId", "SurveyVersion" });
            DropIndex("dbo.Survey", new[] { "AuthorId" });
            DropIndex("dbo.Survey", new[] { "SettingsId" });
            DropIndex("dbo.SurveyLookup", new[] { "PageId" });
            DropIndex("dbo.SurveyLookup", new[] { "SurveyId", "SurveyVersion" });
            DropIndex("dbo.Question", new[] { "TypeId" });
            DropIndex("dbo.Question", new[] { "PageId" });
            DropIndex("dbo.QuestionAnswer", new[] { "QuestionId" });
            DropIndex("dbo.QuestionAnswer", new[] { "SurveyResponseId" });
            DropTable("dbo.QuestionType");
            DropTable("dbo.Template");
            DropTable("dbo.TemplateLookup");
            DropTable("dbo.SurveySettings");
            DropTable("dbo.SurveyResponse");
            DropTable("dbo.Survey");
            DropTable("dbo.SurveyLookup");
            DropTable("dbo.SurveyPage");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionAnswer");
        }
    }
}
