using System.Data.Entity.Migrations;

namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    
    public partial class AddSurveys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .ForeignKey("dbo.QuestionType", t => t.TypeId)
                .ForeignKey("dbo.Page", t => t.PageId)
                .Index(t => t.PageId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.QuestionAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyResponseId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.SurveyResponse", t => t.SurveyResponseId)
                .Index(t => t.SurveyResponseId)
                .Index(t => t.QuestionId);
            
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
                "dbo.QuestionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurveyTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAnswerQuestionVariants",
                c => new
                    {
                        QuestionAnswer_Id = c.Int(nullable: false),
                        QuestionVariant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionAnswer_Id, t.QuestionVariant_Id })
                .ForeignKey("dbo.QuestionAnswer", t => t.QuestionAnswer_Id, cascadeDelete: true)
                .ForeignKey("dbo.QuestionVariant", t => t.QuestionVariant_Id, cascadeDelete: true)
                .Index(t => t.QuestionAnswer_Id)
                .Index(t => t.QuestionVariant_Id);
            
            CreateTable(
                "dbo.SurveyPage",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SurveyVersionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.Id)
                .ForeignKey("dbo.SurveyVersion", t => t.SurveyVersionId)
                .Index(t => t.Id)
                .Index(t => t.SurveyVersionId);
            
            CreateTable(
                "dbo.TemplatePage",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Page", t => t.Id)
                .ForeignKey("dbo.SurveyTemplate", t => t.TemplateId)
                .Index(t => t.Id)
                .Index(t => t.TemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplatePage", "TemplateId", "dbo.SurveyTemplate");
            DropForeignKey("dbo.TemplatePage", "Id", "dbo.Page");
            DropForeignKey("dbo.SurveyPage", "SurveyVersionId", "dbo.SurveyVersion");
            DropForeignKey("dbo.SurveyPage", "Id", "dbo.Page");
            DropForeignKey("dbo.Question", "PageId", "dbo.Page");
            DropForeignKey("dbo.QuestionVariant", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Question", "TypeId", "dbo.QuestionType");
            DropForeignKey("dbo.QuestionAnswerQuestionVariants", "QuestionVariant_Id", "dbo.QuestionVariant");
            DropForeignKey("dbo.QuestionAnswerQuestionVariants", "QuestionAnswer_Id", "dbo.QuestionAnswer");
            DropForeignKey("dbo.QuestionAnswer", "SurveyResponseId", "dbo.SurveyResponse");
            DropForeignKey("dbo.SurveyResponse", "UserId", "dbo.Users");
            DropForeignKey("dbo.SurveyResponse", "SurveyVersionId", "dbo.SurveyVersion");
            DropForeignKey("dbo.SurveyVersion", "SurveyId", "dbo.Survey");
            DropForeignKey("dbo.Survey", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.QuestionAnswer", "QuestionId", "dbo.Question");
            DropIndex("dbo.TemplatePage", new[] { "TemplateId" });
            DropIndex("dbo.TemplatePage", new[] { "Id" });
            DropIndex("dbo.SurveyPage", new[] { "SurveyVersionId" });
            DropIndex("dbo.SurveyPage", new[] { "Id" });
            DropIndex("dbo.QuestionAnswerQuestionVariants", new[] { "QuestionVariant_Id" });
            DropIndex("dbo.QuestionAnswerQuestionVariants", new[] { "QuestionAnswer_Id" });
            DropIndex("dbo.QuestionVariant", new[] { "QuestionId" });
            DropIndex("dbo.Survey", new[] { "AuthorId" });
            DropIndex("dbo.SurveyVersion", new[] { "SurveyId" });
            DropIndex("dbo.SurveyResponse", new[] { "UserId" });
            DropIndex("dbo.SurveyResponse", new[] { "SurveyVersionId" });
            DropIndex("dbo.QuestionAnswer", new[] { "QuestionId" });
            DropIndex("dbo.QuestionAnswer", new[] { "SurveyResponseId" });
            DropIndex("dbo.Question", new[] { "TypeId" });
            DropIndex("dbo.Question", new[] { "PageId" });
            DropTable("dbo.TemplatePage");
            DropTable("dbo.SurveyPage");
            DropTable("dbo.QuestionAnswerQuestionVariants");
            DropTable("dbo.SurveyTemplate");
            DropTable("dbo.QuestionType");
            DropTable("dbo.QuestionVariant");
            DropTable("dbo.Survey");
            DropTable("dbo.SurveyVersion");
            DropTable("dbo.SurveyResponse");
            DropTable("dbo.QuestionAnswer");
            DropTable("dbo.Question");
            DropTable("dbo.Page");
        }
    }
}