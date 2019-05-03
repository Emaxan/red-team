using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Repositories.EF;

namespace RedTeam.TechArtSurvey.Repositories.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TechArtSurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(TechArtSurveyContext context)
        {
            var roleNames = Enum.GetNames(typeof(RoleTypes));
            for (var i = 0; i < roleNames.Length; i++)
            {
                context.Roles.AddOrUpdate(new Role
                                          {
                                              Id = i + 1,
                                              Name = roleNames[i],
                                              RoleType = (RoleTypes)i
                                          });
            }

            context.Users.AddOrUpdate(u => u.Email,
                                      new User
                                      {
                                          Id = 1,
                                          UserName = "Admin",
                                          Email = "admin@admin.admin",
                                          Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                                          RoleId = (int)RoleTypes.Admin + 1
                                      },
                                      new User
                                      {
                                          Id = 2,
                                          UserName = "User",
                                          Email = "user@user.user",
                                          Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                                          RoleId = (int)RoleTypes.User + 1
                                      },
                                      new User
                                      {
                                          Id = 3,
                                          UserName = "Максим Ермошин",
                                          Email = "emaxan1997@gmail.com",
                                          Password = "AE8hbQkihuUpfHqZKr4OnCGoa+yiI+ItOGL3kJg4Rr2/ZiPVaiuqa5zMcuE5Iqrbeg==",
                                          RoleId = (int)RoleTypes.Admin + 1
                                      });

            var questionTypeNames = Enum.GetNames(typeof(QuestionTypes));
            for (var i = 0; i < questionTypeNames.Length; i++)
            {
                context.QuestionTypes.AddOrUpdate(new QuestionType
                                                  {
                                                      Id = i + 1,
                                                      Name = questionTypeNames[i],
                                                      Type = (QuestionTypes)i
                                                  });
            }

            context.Surveys.AddOrUpdate(s => s.Id,
                                        new Survey
                                        {
                                            Id = 1,
                                            AuthorId = 3,
                                        });

            var localizableStrings = new List<LocalizableString>
            {
                new LocalizableString {StringId = 1, Default = "First page"},
                new LocalizableString {StringId = 2, Default = "Second page"},
                new LocalizableString {StringId = 3, Default = "Third page"},
                new LocalizableString {StringId = 4, Default = "私First template page"},
                new LocalizableString {StringId = 5, Default = "Second template page"},
                new LocalizableString {StringId = 6, Default = "Third template page"},
                new LocalizableString {StringId = 7, Default = "My test survey"},
                new LocalizableString {StringId = 8, Default = "My first CompletedHtml"},
                new LocalizableString {StringId = 9, Default = "My first StartSurveyText"},
                new LocalizableString {StringId = 10, Default = "My first PagePrevText"},
                new LocalizableString {StringId = 11, Default = "My first PageNextText"},
                new LocalizableString {StringId = 12, Default = "My first CompleteText"},
                new LocalizableString {StringId = 13, Default = "My first template"},
                new LocalizableString {StringId = 14, Default = "My first template description"},
                new LocalizableString {StringId = 15, Default = "My first CompletedHtml"},
                new LocalizableString {StringId = 16, Default = "My first StartSurveyText"},
                new LocalizableString {StringId = 17, Default = "My first PagePrevText"},
                new LocalizableString {StringId = 18, Default = "My first PageNextText"},
                new LocalizableString {StringId = 19, Default = "My first CompleteText"},
                new LocalizableString {StringId = 20, Default = "Option 1"},
                new LocalizableString {StringId = 21, Default = "Option 2"},
                new LocalizableString {StringId = 22, Default = "Option 3"},
                new LocalizableString {StringId = 23, Default = "First question"},
                new LocalizableString {StringId = 24, Default = "Second question"},
                new LocalizableString {StringId = 25, Default = "Third question"},
                new LocalizableString {StringId = 26, Default = "First Placeholder"},
                new LocalizableString {StringId = 27, Default = "Second Placeholder"},
                new LocalizableString {StringId = 28, Default = "Third Placeholder"},
                new LocalizableString {StringId = 29, Default = "First question"},
                new LocalizableString {StringId = 30, Default = "Second question"},
                new LocalizableString {StringId = 31, Default = "Third question"},
                new LocalizableString {StringId = 32, Default = "First Placeholder"},
                new LocalizableString {StringId = 33, Default = "Second Placeholder"},
                new LocalizableString {StringId = 34, Default = "Third Placeholder"},
                new LocalizableString {StringId = 35, Default = ""},
            };

            localizableStrings.ForEach(ls => context.LocalizableStrings.AddOrUpdate(locs => locs.StringId, ls));

            context.SurveyVersions.AddOrUpdate(sv => sv.Id,
                                               new SurveyVersion
                                               {
                                                   Id = 1,
                                                   Number = 1,
                                                   TitleId = 7,
                                                   CreatedDate = DateTime.Now,
                                                   StartDate = DateTime.Now,
                                                   EndDate = DateTime.Now,
                                                   SurveyId = 1,
                                                   CompletedHtmlId = 8,
                                                   StartSurveyTextId = 9,
                                                   PagePrevTextId = 10,
                                                   PageNextTextId = 11,
                                                   CompleteTextId = 12,
                                                   Settings = new SurveySettings
                                                   {
                                                       Locale = "ru",
                                                       QuestionsOrder = "random",
                                                       FirstPageIsStarted = false,
                                                       ShowCompletedPage = true,
                                                       ShowPageNumbers = true,
                                                       IsSinglePage = false,
                                                       GoNextPageAutomatic = true,
                                                       ShowPrevButton = true,
                                                       RequiredText = "*",
                                                       MaxTimeToFinish = 0,
                                                       MaxTimeToFinishPage = 0,
                                                       QuestionErrorLocation = "top",
                                                       QuestionTitleLocation = "top",
                                                       ShowNavigationButtons = "both",
                                                       ShowProgressBar = "bottom",
                                                       ShowQuestionNumbers = "on",
                                                       ShowTimerPanel = "top",
                                                       ShowTimerPanelMode = "all"
                                                   },
                                                   Pages = new List<SurveyPage>()
                                               });

            context.Templates.AddOrUpdate(t => t.Id,
                                          new SurveyTemplate
                                          {
                                              Id = 1,
                                              TitleId = 13,
                                              DescriptionId = 14,
                                              CreatedDate = DateTime.Now,
                                              AuthorId = 3,
                                              CompletedHtmlId = 15,
                                              StartSurveyTextId = 16,
                                              PagePrevTextId = 17,
                                              PageNextTextId = 18,
                                              CompleteTextId = 19,
                                              Settings = new SurveySettings
                                              {
                                                  Locale = "ru",
                                                  QuestionsOrder = "random",
                                                  FirstPageIsStarted = false,
                                                  ShowCompletedPage = true,
                                                  ShowPageNumbers = true,
                                                  IsSinglePage = false,
                                                  GoNextPageAutomatic = true,
                                                  ShowPrevButton = true,
                                                  RequiredText = "*",
                                                  MaxTimeToFinish = 0,
                                                  MaxTimeToFinishPage = 0,
                                                  QuestionErrorLocation = "top",
                                                  QuestionTitleLocation = "top",
                                                  ShowNavigationButtons = "both",
                                                  ShowProgressBar = "bottom",
                                                  ShowQuestionNumbers = "on",
                                                  ShowTimerPanel = "top",
                                                  ShowTimerPanelMode = "both"
                                              },
                                              Pages = new List<TemplatePage>()
                                          });

            var pages = new List<Page>
                        {
                            new SurveyPage
                            {
                                Id = 1,
                                Name = "Page 1",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 1,
                                SurveyVersionId = 1
                            },
                            new SurveyPage
                            {
                                Id = 2,
                                Name = "Page 2",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 2,
                                SurveyVersionId = 1
                            },
                            new SurveyPage
                            {
                                Id = 3,
                                Name = "Page 3",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 3,
                                SurveyVersionId = 1
                            },
                            new TemplatePage
                            {
                                Id = 4,
                                Name = "Page 1",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 4,
                                TemplateId = 1
                            },
                            new TemplatePage
                            {
                                Id = 5,
                                Name = "Page 2",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 5,
                                TemplateId = 1
                            },
                            new TemplatePage
                            {
                                Id = 6,
                                Name = "Page 3",
                                VisibleIf = "",
                                QuestionsOrder = "initial",
                                Visible = true,
                                TitleId = 6,
                                TemplateId = 1
                            }
                        };

            pages.ForEach(p => context.Pages.AddOrUpdate(sp => sp.Id, p));

            context.Questions.AddOrUpdate(q => q.Id,
                new Text()
                {
                    Id = 1,
                    PageId = 1,
                    Name = "question1",
                    TitleId = 23,
                    TypeId = (int) QuestionTypes.Text + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    PlaceholderId = 26,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    InputType = "text"
                },
                new Checkbox()
                {
                    Id = 2,
                    PageId = 2,
                    Name = "question2",
                    TitleId = 24,
                    TypeId = (int) QuestionTypes.Checkbox + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    HasOther = true,
                    ChoicesOrder = "random",
                    PlaceholderId = 27,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    ColCount = 3
                },
                new Text()
                {
                    Id = 3,
                    PageId = 3,
                    Name = "question3",
                    TitleId = 25,
                    TypeId = (int) QuestionTypes.Text + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    PlaceholderId = 28,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    InputType = "text"
                },
                new Text()
                {
                    Id = 4,
                    PageId = 4,
                    Name = "question1",
                    TitleId = 29,
                    TypeId = (int) QuestionTypes.Text + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    PlaceholderId = 32,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    InputType = "text"
                },
                new Text()
                {
                    Id = 5,
                    PageId = 5,
                    Name = "question2",
                    TitleId = 30,
                    TypeId = (int) QuestionTypes.Text + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    PlaceholderId = 33,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    InputType = "text"
                },
                new Text()
                {
                    Id = 6,
                    PageId = 6,
                    Name = "question3",
                    TitleId = 31,
                    TypeId = (int) QuestionTypes.Text + 1,
                    IsRequired = true,
                    VisibleIf = "",
                    EnableIf = "",
                    Visible = true,
                    StartWithNewLine = true,
                    PlaceholderId = 34,
                    MinRateDescriptionId = 35,
                    MaxRateDescriptionId = 35,
                    OptionsCaptionId = 35,
                    InputType = "text"
                });

            var questionVariants = new List<QuestionVariant>
                                   {
                                       new QuestionVariant
                                       {
                                           Id = 1,
                                           TextId = 20,
                                           QuestionId = 2,
                                           UsageStat = 0,
                                           Value = "qv1",
                                           VisibleIf = "",
                                           EnableIf = ""

                                       },
                                       new QuestionVariant
                                       {
                                           Id = 2,
                                           TextId = 21,
                                           QuestionId = 2,
                                           UsageStat = 0,
                                           Value = "qv2",
                                           VisibleIf = "",
                                           EnableIf = ""
                                       },
                                       new QuestionVariant
                                       {
                                           Id = 3,
                                           TextId = 22,
                                           QuestionId = 2,
                                           UsageStat = 0,
                                           Value = "qv3",
                                           VisibleIf = "",
                                           EnableIf = ""
                                       },
                                   };

            questionVariants.ForEach(qv => context.QuestionVariants.AddOrUpdate(qv));

            //context.SurveyResponses.AddOrUpdate(sr => sr.Id,
            //                                    new SurveyResponse
            //                                    {
            //                                        Id = 1,
            //                                        SurveyVersionId = 1,
            //                                        UserId = 2,
            //                                        PassedDate = DateTime.Now
            //                                    });

            //context.QuestionAnswers.AddOrUpdate(qa => new
            //                                          {
            //                                              qa.QuestionId,
            //                                              qa.SurveyResponseId
            //                                          },
            //                                    new QuestionAnswer
            //                                    {
            //                                        QuestionId = 1,
            //                                        SurveyResponseId = 1,
            //                                        Value = "Answer 1"
            //                                    },
            //                                    new QuestionAnswer
            //                                    {
            //                                        QuestionId = 2,
            //                                        SurveyResponseId = 1,
            //                                        Value = "Answer 2"
            //                                    },
            //                                    new QuestionAnswer
            //                                    {
            //                                        QuestionId = 3,
            //                                        SurveyResponseId = 1,
            //                                        Value = "Answer 3"
            //                                    });


        }
    }
}