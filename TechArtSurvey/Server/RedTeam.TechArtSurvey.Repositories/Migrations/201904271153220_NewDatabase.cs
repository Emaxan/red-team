namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalizableString",
                c => new
                    {
                        StringId = c.Int(nullable: false, identity: true),
                        Default = c.String(nullable: false),
                        En = c.String(),
                        Ru = c.String(),
                        Ja = c.String(),
                        ZhCn = c.String(),
                        ZhTw = c.String(),
                        Bg = c.String(),
                        Pl = c.String(),
                        Es = c.String(),
                        De = c.String(),
                        Da = c.String(),
                        It = c.String(),
                        Nl = c.String(),
                        Id = c.String(),
                        Lt = c.String(),
                        Lv = c.String(),
                        No = c.String(),
                        Pt = c.String(),
                        Ro = c.String(),
                        Sv = c.String(),
                        Tr = c.String(),
                        Ko = c.String(),
                        Ka = c.String(),
                        Is = c.String(),
                        Hu = c.String(),
                        He = c.String(),
                        Gr = c.String(),
                        Fr = c.String(),
                        Fi = c.String(),
                        Fa = c.String(),
                        Cz = c.String(),
                        Ca = c.String(),
                        Ar = c.String(),
                    })
                .PrimaryKey(t => t.StringId);
            
            CreateTable(
                "dbo.Trigger",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Expression = c.String(nullable: false),
                        SurveyVersionId = c.Int(nullable: false),
                        SurveyTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SurveyTemplate", t => t.SurveyTemplate_Id)
                .ForeignKey("dbo.SurveyVersion", t => t.SurveyVersionId)
                .Index(t => t.SurveyVersionId)
                .Index(t => t.SurveyTemplate_Id);
            
            CreateTable(
                "dbo.MatrixCol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                        VisibleIf = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.LocalizableString", t => t.TextId)
                .Index(t => t.TextId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.MatrixRow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                        VisibleIf = c.String(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.LocalizableString", t => t.TextId)
                .Index(t => t.TextId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.VisibleTriggerPages",
                c => new
                    {
                        VisibleTrigger_Id = c.Int(nullable: false),
                        Page_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisibleTrigger_Id, t.Page_Id })
                .ForeignKey("dbo.VisibleTrigger", t => t.VisibleTrigger_Id, cascadeDelete: true)
                .ForeignKey("dbo.Page", t => t.Page_Id, cascadeDelete: true)
                .Index(t => t.VisibleTrigger_Id)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.VisibleTriggerQuestions",
                c => new
                    {
                        VisibleTrigger_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VisibleTrigger_Id, t.Question_Id })
                .ForeignKey("dbo.VisibleTrigger", t => t.VisibleTrigger_Id, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.VisibleTrigger_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.TextArea",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Text",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InputType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Dropdown",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HasOther = c.Boolean(nullable: false),
                        ChoicesOrder = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Checkbox",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HasOther = c.Boolean(nullable: false),
                        ColCount = c.Int(nullable: false),
                        ChoicesOrder = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BarRating",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ChoicesOrder = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RadioGroup",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        HasOther = c.Boolean(nullable: false),
                        ColCount = c.Int(nullable: false),
                        ChoicesOrder = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.VisibleTrigger",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trigger", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RunExpressionTrigger",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SetToName = c.String(nullable: false),
                        RunExpression = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trigger", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SetValueTrigger",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SetToName = c.String(nullable: false),
                        SetValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trigger", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CopyValueTrigger",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SetToName = c.String(nullable: false),
                        FromName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trigger", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Page", "TitleId", c => c.Int(nullable: false));
            AddColumn("dbo.Page", "VisibleIf", c => c.String(nullable: false));
            AddColumn("dbo.Page", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Page", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Page", "QuestionsOrder", c => c.String(nullable: false));
            AddColumn("dbo.Question", "TitleId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Question", "EnableIf", c => c.String(nullable: false));
            AddColumn("dbo.Question", "VisibleIf", c => c.String(nullable: false));
            AddColumn("dbo.Question", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Question", "StartWithNewLine", c => c.Boolean(nullable: false));
            AddColumn("dbo.Question", "PlaceholderId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "MinRateDescriptionId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "MaxRateDescriptionId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "OptionsCaptionId", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.SurveyVersion", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "TitleId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "CompletedHtmlId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "StartSurveyTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "PagePrevTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "PageNextTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "CompleteTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "Locale", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowPrevButton", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowCompletedPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowPageNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "GoNextPageAutomatic", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "FirstPageIsStarted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "IsSinglePage", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "RequiredText", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "MaxTimeToFinish", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "MaxTimeToFinishPage", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowNavigationButtons", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "QuestionTitleLocation", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "QuestionErrorLocation", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowProgressBar", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowTimerPanel", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "QuestionsOrder", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowQuestionNumbers", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "ShowTimerPanelMode", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SurveyVersion", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SurveyVersion", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuestionVariant", "TextId", c => c.Int(nullable: false));
            AddColumn("dbo.QuestionVariant", "Value", c => c.String(nullable: false));
            AddColumn("dbo.QuestionVariant", "VisibleIf", c => c.String(nullable: false));
            AddColumn("dbo.QuestionVariant", "EnableIf", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "TitleId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "CompletedHtmlId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "StartSurveyTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "PagePrevTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "PageNextTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "CompleteTextId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_Locale", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowPrevButton", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowCompletedPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowPageNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_GoNextPageAutomatic", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_FirstPageIsStarted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_IsSinglePage", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_RequiredText", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_MaxTimeToFinish", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_MaxTimeToFinishPage", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowNavigationButtons", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_QuestionTitleLocation", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_QuestionErrorLocation", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowProgressBar", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowTimerPanel", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_QuestionsOrder", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowQuestionNumbers", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Settings_ShowTimerPanelMode", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SurveyTemplate", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "DescriptionId", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyTemplate", "CompletedHtml_StringId", c => c.Int());
            AddColumn("dbo.SurveyTemplate", "CompleteText_StringId", c => c.Int());
            AddColumn("dbo.SurveyTemplate", "PageNextText_StringId", c => c.Int());
            AddColumn("dbo.SurveyTemplate", "PagePrevText_StringId", c => c.Int());
            AddColumn("dbo.SurveyTemplate", "StartSurveyText_StringId", c => c.Int());
            CreateIndex("dbo.Page", "TitleId");
            CreateIndex("dbo.Question", "TitleId");
            CreateIndex("dbo.Question", "PlaceholderId");
            CreateIndex("dbo.Question", "MinRateDescriptionId");
            CreateIndex("dbo.Question", "MaxRateDescriptionId");
            CreateIndex("dbo.Question", "OptionsCaptionId");
            CreateIndex("dbo.SurveyVersion", "TitleId");
            CreateIndex("dbo.SurveyVersion", "CompletedHtmlId");
            CreateIndex("dbo.SurveyVersion", "StartSurveyTextId");
            CreateIndex("dbo.SurveyVersion", "PagePrevTextId");
            CreateIndex("dbo.SurveyVersion", "PageNextTextId");
            CreateIndex("dbo.SurveyVersion", "CompleteTextId");
            CreateIndex("dbo.SurveyTemplate", "TitleId");
            CreateIndex("dbo.SurveyTemplate", "AuthorId");
            CreateIndex("dbo.SurveyTemplate", "DescriptionId");
            CreateIndex("dbo.SurveyTemplate", "CompletedHtml_StringId");
            CreateIndex("dbo.SurveyTemplate", "CompleteText_StringId");
            CreateIndex("dbo.SurveyTemplate", "PageNextText_StringId");
            CreateIndex("dbo.SurveyTemplate", "PagePrevText_StringId");
            CreateIndex("dbo.SurveyTemplate", "StartSurveyText_StringId");
            CreateIndex("dbo.QuestionVariant", "TextId");
            AddForeignKey("dbo.SurveyVersion", "CompletedHtmlId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyVersion", "CompleteTextId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyVersion", "PageNextTextId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyVersion", "PagePrevTextId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyVersion", "StartSurveyTextId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "AuthorId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SurveyTemplate", "CompletedHtml_StringId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "CompleteText_StringId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "DescriptionId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "PageNextText_StringId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "PagePrevText_StringId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "StartSurveyText_StringId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyTemplate", "TitleId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.SurveyVersion", "TitleId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.QuestionVariant", "TextId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Question", "MaxRateDescriptionId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Question", "MinRateDescriptionId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Question", "OptionsCaptionId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Question", "PlaceholderId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Question", "TitleId", "dbo.LocalizableString", "StringId");
            AddForeignKey("dbo.Page", "TitleId", "dbo.LocalizableString", "StringId");
            DropColumn("dbo.Page", "Title");
            DropColumn("dbo.Page", "Number");
            DropColumn("dbo.Question", "Default");
            DropColumn("dbo.Question", "Title");
            DropColumn("dbo.Question", "Number");
            DropColumn("dbo.SurveyVersion", "Version");
            DropColumn("dbo.SurveyVersion", "Title");
            DropColumn("dbo.SurveyVersion", "IsAnonymous");
            DropColumn("dbo.SurveyVersion", "HasQuestionNumbers");
            DropColumn("dbo.SurveyVersion", "HasPageNumbers");
            DropColumn("dbo.SurveyVersion", "IsRandomOrdered");
            DropColumn("dbo.SurveyVersion", "HasRequiredFieldsStars");
            DropColumn("dbo.SurveyVersion", "HasProgressIndicator");
            DropColumn("dbo.SurveyVersion", "UpdatedDate");
            DropColumn("dbo.Survey", "CreatedDate");
            DropColumn("dbo.QuestionVariant", "Text");
            DropColumn("dbo.SurveyTemplate", "Title");
            DropColumn("dbo.SurveyTemplate", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyTemplate", "Description", c => c.String(nullable: false));
            AddColumn("dbo.SurveyTemplate", "Title", c => c.String(nullable: false));
            AddColumn("dbo.QuestionVariant", "Text", c => c.String(nullable: false));
            AddColumn("dbo.Survey", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SurveyVersion", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SurveyVersion", "HasProgressIndicator", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "HasRequiredFieldsStars", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "IsRandomOrdered", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "HasPageNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "HasQuestionNumbers", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "IsAnonymous", c => c.Boolean(nullable: false));
            AddColumn("dbo.SurveyVersion", "Title", c => c.String(nullable: false));
            AddColumn("dbo.SurveyVersion", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Question", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Question", "Default", c => c.String());
            AddColumn("dbo.Page", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Page", "Title", c => c.String(nullable: false));
            DropForeignKey("dbo.CopyValueTrigger", "Id", "dbo.Trigger");
            DropForeignKey("dbo.SetValueTrigger", "Id", "dbo.Trigger");
            DropForeignKey("dbo.RunExpressionTrigger", "Id", "dbo.Trigger");
            DropForeignKey("dbo.VisibleTrigger", "Id", "dbo.Trigger");
            DropForeignKey("dbo.RadioGroup", "Id", "dbo.Question");
            DropForeignKey("dbo.BarRating", "Id", "dbo.Question");
            DropForeignKey("dbo.Checkbox", "Id", "dbo.Question");
            DropForeignKey("dbo.Dropdown", "Id", "dbo.Question");
            DropForeignKey("dbo.Text", "Id", "dbo.Question");
            DropForeignKey("dbo.TextArea", "Id", "dbo.Question");
            DropForeignKey("dbo.Page", "TitleId", "dbo.LocalizableString");
            DropForeignKey("dbo.Question", "TitleId", "dbo.LocalizableString");
            DropForeignKey("dbo.Question", "PlaceholderId", "dbo.LocalizableString");
            DropForeignKey("dbo.Question", "OptionsCaptionId", "dbo.LocalizableString");
            DropForeignKey("dbo.Question", "MinRateDescriptionId", "dbo.LocalizableString");
            DropForeignKey("dbo.Question", "MaxRateDescriptionId", "dbo.LocalizableString");
            DropForeignKey("dbo.MatrixRow", "TextId", "dbo.LocalizableString");
            DropForeignKey("dbo.MatrixRow", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.MatrixCol", "TextId", "dbo.LocalizableString");
            DropForeignKey("dbo.MatrixCol", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionVariant", "TextId", "dbo.LocalizableString");
            DropForeignKey("dbo.Trigger", "SurveyVersionId", "dbo.SurveyVersion");
            DropForeignKey("dbo.SurveyVersion", "TitleId", "dbo.LocalizableString");
            DropForeignKey("dbo.Trigger", "SurveyTemplate_Id", "dbo.SurveyTemplate");
            DropForeignKey("dbo.SurveyTemplate", "TitleId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "StartSurveyText_StringId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "PagePrevText_StringId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "PageNextText_StringId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "DescriptionId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "CompleteText_StringId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "CompletedHtml_StringId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyTemplate", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.SurveyVersion", "StartSurveyTextId", "dbo.LocalizableString");
            DropForeignKey("dbo.VisibleTriggerQuestions", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.VisibleTriggerQuestions", "VisibleTrigger_Id", "dbo.VisibleTrigger");
            DropForeignKey("dbo.VisibleTriggerPages", "Page_Id", "dbo.Page");
            DropForeignKey("dbo.VisibleTriggerPages", "VisibleTrigger_Id", "dbo.VisibleTrigger");
            DropForeignKey("dbo.SurveyVersion", "PagePrevTextId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyVersion", "PageNextTextId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyVersion", "CompleteTextId", "dbo.LocalizableString");
            DropForeignKey("dbo.SurveyVersion", "CompletedHtmlId", "dbo.LocalizableString");
            DropIndex("dbo.CopyValueTrigger", new[] { "Id" });
            DropIndex("dbo.SetValueTrigger", new[] { "Id" });
            DropIndex("dbo.RunExpressionTrigger", new[] { "Id" });
            DropIndex("dbo.VisibleTrigger", new[] { "Id" });
            DropIndex("dbo.RadioGroup", new[] { "Id" });
            DropIndex("dbo.BarRating", new[] { "Id" });
            DropIndex("dbo.Checkbox", new[] { "Id" });
            DropIndex("dbo.Dropdown", new[] { "Id" });
            DropIndex("dbo.Text", new[] { "Id" });
            DropIndex("dbo.TextArea", new[] { "Id" });
            DropIndex("dbo.VisibleTriggerQuestions", new[] { "Question_Id" });
            DropIndex("dbo.VisibleTriggerQuestions", new[] { "VisibleTrigger_Id" });
            DropIndex("dbo.VisibleTriggerPages", new[] { "Page_Id" });
            DropIndex("dbo.VisibleTriggerPages", new[] { "VisibleTrigger_Id" });
            DropIndex("dbo.MatrixRow", new[] { "QuestionId" });
            DropIndex("dbo.MatrixRow", new[] { "TextId" });
            DropIndex("dbo.MatrixCol", new[] { "QuestionId" });
            DropIndex("dbo.MatrixCol", new[] { "TextId" });
            DropIndex("dbo.QuestionVariant", new[] { "TextId" });
            DropIndex("dbo.SurveyTemplate", new[] { "StartSurveyText_StringId" });
            DropIndex("dbo.SurveyTemplate", new[] { "PagePrevText_StringId" });
            DropIndex("dbo.SurveyTemplate", new[] { "PageNextText_StringId" });
            DropIndex("dbo.SurveyTemplate", new[] { "CompleteText_StringId" });
            DropIndex("dbo.SurveyTemplate", new[] { "CompletedHtml_StringId" });
            DropIndex("dbo.SurveyTemplate", new[] { "DescriptionId" });
            DropIndex("dbo.SurveyTemplate", new[] { "AuthorId" });
            DropIndex("dbo.SurveyTemplate", new[] { "TitleId" });
            DropIndex("dbo.Trigger", new[] { "SurveyTemplate_Id" });
            DropIndex("dbo.Trigger", new[] { "SurveyVersionId" });
            DropIndex("dbo.SurveyVersion", new[] { "CompleteTextId" });
            DropIndex("dbo.SurveyVersion", new[] { "PageNextTextId" });
            DropIndex("dbo.SurveyVersion", new[] { "PagePrevTextId" });
            DropIndex("dbo.SurveyVersion", new[] { "StartSurveyTextId" });
            DropIndex("dbo.SurveyVersion", new[] { "CompletedHtmlId" });
            DropIndex("dbo.SurveyVersion", new[] { "TitleId" });
            DropIndex("dbo.Question", new[] { "OptionsCaptionId" });
            DropIndex("dbo.Question", new[] { "MaxRateDescriptionId" });
            DropIndex("dbo.Question", new[] { "MinRateDescriptionId" });
            DropIndex("dbo.Question", new[] { "PlaceholderId" });
            DropIndex("dbo.Question", new[] { "TitleId" });
            DropIndex("dbo.Page", new[] { "TitleId" });
            DropColumn("dbo.SurveyTemplate", "StartSurveyText_StringId");
            DropColumn("dbo.SurveyTemplate", "PagePrevText_StringId");
            DropColumn("dbo.SurveyTemplate", "PageNextText_StringId");
            DropColumn("dbo.SurveyTemplate", "CompleteText_StringId");
            DropColumn("dbo.SurveyTemplate", "CompletedHtml_StringId");
            DropColumn("dbo.SurveyTemplate", "DescriptionId");
            DropColumn("dbo.SurveyTemplate", "AuthorId");
            DropColumn("dbo.SurveyTemplate", "CreatedDate");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowTimerPanelMode");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowQuestionNumbers");
            DropColumn("dbo.SurveyTemplate", "Settings_QuestionsOrder");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowTimerPanel");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowProgressBar");
            DropColumn("dbo.SurveyTemplate", "Settings_QuestionErrorLocation");
            DropColumn("dbo.SurveyTemplate", "Settings_QuestionTitleLocation");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowNavigationButtons");
            DropColumn("dbo.SurveyTemplate", "Settings_MaxTimeToFinishPage");
            DropColumn("dbo.SurveyTemplate", "Settings_MaxTimeToFinish");
            DropColumn("dbo.SurveyTemplate", "Settings_RequiredText");
            DropColumn("dbo.SurveyTemplate", "Settings_IsSinglePage");
            DropColumn("dbo.SurveyTemplate", "Settings_FirstPageIsStarted");
            DropColumn("dbo.SurveyTemplate", "Settings_GoNextPageAutomatic");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowPageNumbers");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowCompletedPage");
            DropColumn("dbo.SurveyTemplate", "Settings_ShowPrevButton");
            DropColumn("dbo.SurveyTemplate", "Settings_Locale");
            DropColumn("dbo.SurveyTemplate", "CompleteTextId");
            DropColumn("dbo.SurveyTemplate", "PageNextTextId");
            DropColumn("dbo.SurveyTemplate", "PagePrevTextId");
            DropColumn("dbo.SurveyTemplate", "StartSurveyTextId");
            DropColumn("dbo.SurveyTemplate", "CompletedHtmlId");
            DropColumn("dbo.SurveyTemplate", "TitleId");
            DropColumn("dbo.QuestionVariant", "EnableIf");
            DropColumn("dbo.QuestionVariant", "VisibleIf");
            DropColumn("dbo.QuestionVariant", "Value");
            DropColumn("dbo.QuestionVariant", "TextId");
            DropColumn("dbo.SurveyVersion", "EndDate");
            DropColumn("dbo.SurveyVersion", "StartDate");
            DropColumn("dbo.SurveyVersion", "CreatedDate");
            DropColumn("dbo.SurveyVersion", "ShowTimerPanelMode");
            DropColumn("dbo.SurveyVersion", "ShowQuestionNumbers");
            DropColumn("dbo.SurveyVersion", "QuestionsOrder");
            DropColumn("dbo.SurveyVersion", "ShowTimerPanel");
            DropColumn("dbo.SurveyVersion", "ShowProgressBar");
            DropColumn("dbo.SurveyVersion", "QuestionErrorLocation");
            DropColumn("dbo.SurveyVersion", "QuestionTitleLocation");
            DropColumn("dbo.SurveyVersion", "ShowNavigationButtons");
            DropColumn("dbo.SurveyVersion", "MaxTimeToFinishPage");
            DropColumn("dbo.SurveyVersion", "MaxTimeToFinish");
            DropColumn("dbo.SurveyVersion", "RequiredText");
            DropColumn("dbo.SurveyVersion", "IsSinglePage");
            DropColumn("dbo.SurveyVersion", "FirstPageIsStarted");
            DropColumn("dbo.SurveyVersion", "GoNextPageAutomatic");
            DropColumn("dbo.SurveyVersion", "ShowPageNumbers");
            DropColumn("dbo.SurveyVersion", "ShowCompletedPage");
            DropColumn("dbo.SurveyVersion", "ShowPrevButton");
            DropColumn("dbo.SurveyVersion", "Locale");
            DropColumn("dbo.SurveyVersion", "CompleteTextId");
            DropColumn("dbo.SurveyVersion", "PageNextTextId");
            DropColumn("dbo.SurveyVersion", "PagePrevTextId");
            DropColumn("dbo.SurveyVersion", "StartSurveyTextId");
            DropColumn("dbo.SurveyVersion", "CompletedHtmlId");
            DropColumn("dbo.SurveyVersion", "TitleId");
            DropColumn("dbo.SurveyVersion", "Number");
            DropColumn("dbo.Question", "Discriminator");
            DropColumn("dbo.Question", "OptionsCaptionId");
            DropColumn("dbo.Question", "MaxRateDescriptionId");
            DropColumn("dbo.Question", "MinRateDescriptionId");
            DropColumn("dbo.Question", "PlaceholderId");
            DropColumn("dbo.Question", "StartWithNewLine");
            DropColumn("dbo.Question", "Visible");
            DropColumn("dbo.Question", "VisibleIf");
            DropColumn("dbo.Question", "EnableIf");
            DropColumn("dbo.Question", "Name");
            DropColumn("dbo.Question", "TitleId");
            DropColumn("dbo.Page", "QuestionsOrder");
            DropColumn("dbo.Page", "Visible");
            DropColumn("dbo.Page", "Name");
            DropColumn("dbo.Page", "VisibleIf");
            DropColumn("dbo.Page", "TitleId");
            DropTable("dbo.CopyValueTrigger");
            DropTable("dbo.SetValueTrigger");
            DropTable("dbo.RunExpressionTrigger");
            DropTable("dbo.VisibleTrigger");
            DropTable("dbo.RadioGroup");
            DropTable("dbo.BarRating");
            DropTable("dbo.Checkbox");
            DropTable("dbo.Dropdown");
            DropTable("dbo.Text");
            DropTable("dbo.TextArea");
            DropTable("dbo.VisibleTriggerQuestions");
            DropTable("dbo.VisibleTriggerPages");
            DropTable("dbo.MatrixRow");
            DropTable("dbo.MatrixCol");
            DropTable("dbo.Trigger");
            DropTable("dbo.LocalizableString");
        }
    }
}