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
                        Default = c.String(),
                        Title = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
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
                "dbo.SurveyVersion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        IsAnonymous = c.Boolean(nullable: false),
                        HasQuestionNumbers = c.Boolean(nullable: false),
                        HasPageNumbers = c.Boolean(nullable: false),
                        IsRandomOrdered = c.Boolean(nullable: false),
                        HasRequiredFieldsStars = c.Boolean(nullable: false),
                        HasProgressIndicator = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        SurveyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Survey", t => t.SurveyId)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.SurveyResponse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PassedDate = c.DateTime(nullable: false),
                        SurveyVersionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyVersion", t => t.SurveyVersionId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.SurveyVersionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
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
            
            CreateTable(
                "dbo.QuestionVariant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.SurveyPageSurveyVersions",
                c => new
                    {
                        SurveyPage_Id = c.Int(nullable: false),
                        SurveyVersion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyPage_Id, t.SurveyVersion_Id })
                .ForeignKey("dbo.SurveyPage", t => t.SurveyPage_Id, cascadeDelete: true)
                .ForeignKey("dbo.SurveyVersion", t => t.SurveyVersion_Id, cascadeDelete: true)
                .Index(t => t.SurveyPage_Id)
                .Index(t => t.SurveyVersion_Id);
            
            CreateTable(
                "dbo.SurveyPageTemplates",
                c => new
                    {
                        SurveyPage_Id = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SurveyPage_Id, t.Template_Id })
                .ForeignKey("dbo.SurveyPage", t => t.SurveyPage_Id, cascadeDelete: true)
                .ForeignKey("dbo.Template", t => t.Template_Id, cascadeDelete: true)
                .Index(t => t.SurveyPage_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.QuestionAnswerQuestionVariants",
                c => new
                    {
                        QuestionAnswer_SurveyResponseId = c.Int(nullable: false),
                        QuestionAnswer_QuestionId = c.Int(nullable: false),
                        QuestionVariant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionAnswer_SurveyResponseId, t.QuestionAnswer_QuestionId, t.QuestionVariant_Id })
                .ForeignKey("dbo.QuestionAnswer", t => new { t.QuestionAnswer_SurveyResponseId, t.QuestionAnswer_QuestionId }, cascadeDelete: true)
                .ForeignKey("dbo.QuestionVariant", t => t.QuestionVariant_Id, cascadeDelete: true)
                .Index(t => new { t.QuestionAnswer_SurveyResponseId, t.QuestionAnswer_QuestionId })
                .Index(t => t.QuestionVariant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswerQuestionVariants", "QuestionVariant_Id", "dbo.QuestionVariant");
            DropForeignKey("dbo.QuestionAnswerQuestionVariants", new[] { "QuestionAnswer_SurveyResponseId", "QuestionAnswer_QuestionId" }, "dbo.QuestionAnswer");
            DropForeignKey("dbo.QuestionAnswer", "SurveyResponseId", "dbo.SurveyResponse");
            DropForeignKey("dbo.QuestionAnswer", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionVariant", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "TypeId", "dbo.QuestionType");
            DropForeignKey("dbo.Question", "PageId", "dbo.SurveyPage");
            DropForeignKey("dbo.SurveyPageTemplates", "Template_Id", "dbo.Template");
            DropForeignKey("dbo.SurveyPageTemplates", "SurveyPage_Id", "dbo.SurveyPage");
            DropForeignKey("dbo.SurveyPageSurveyVersions", "SurveyVersion_Id", "dbo.SurveyVersion");
            DropForeignKey("dbo.SurveyPageSurveyVersions", "SurveyPage_Id", "dbo.SurveyPage");
            DropForeignKey("dbo.SurveyResponse", "UserId", "dbo.Users");
            DropForeignKey("dbo.SurveyVersion", "SurveyId", "dbo.Survey");
            DropForeignKey("dbo.Survey", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.SurveyResponse", "SurveyVersionId", "dbo.SurveyVersion");
            DropIndex("dbo.QuestionAnswerQuestionVariants", new[] { "QuestionVariant_Id" });
            DropIndex("dbo.QuestionAnswerQuestionVariants", new[] { "QuestionAnswer_SurveyResponseId", "QuestionAnswer_QuestionId" });
            DropIndex("dbo.SurveyPageTemplates", new[] { "Template_Id" });
            DropIndex("dbo.SurveyPageTemplates", new[] { "SurveyPage_Id" });
            DropIndex("dbo.SurveyPageSurveyVersions", new[] { "SurveyVersion_Id" });
            DropIndex("dbo.SurveyPageSurveyVersions", new[] { "SurveyPage_Id" });
            DropIndex("dbo.QuestionVariant", new[] { "QuestionId" });
            DropIndex("dbo.Survey", new[] { "AuthorId" });
            DropIndex("dbo.SurveyResponse", new[] { "UserId" });
            DropIndex("dbo.SurveyResponse", new[] { "SurveyVersionId" });
            DropIndex("dbo.SurveyVersion", new[] { "SurveyId" });
            DropIndex("dbo.Question", new[] { "TypeId" });
            DropIndex("dbo.Question", new[] { "PageId" });
            DropIndex("dbo.QuestionAnswer", new[] { "QuestionId" });
            DropIndex("dbo.QuestionAnswer", new[] { "SurveyResponseId" });
            DropTable("dbo.QuestionAnswerQuestionVariants");
            DropTable("dbo.SurveyPageTemplates");
            DropTable("dbo.SurveyPageSurveyVersions");
            DropTable("dbo.QuestionVariant");
            DropTable("dbo.QuestionType");
            DropTable("dbo.Template");
            DropTable("dbo.Survey");
            DropTable("dbo.SurveyResponse");
            DropTable("dbo.SurveyVersion");
            DropTable("dbo.SurveyPage");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionAnswer");
        }
    }
}
