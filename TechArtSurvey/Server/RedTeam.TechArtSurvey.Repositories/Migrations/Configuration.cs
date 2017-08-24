using System;
using System.Data.Entity.Migrations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
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
                context.Roles.AddOrUpdate(new Role()
                                          {
                                              Id = i + 1,
                                              Name = roleNames[i],
                                              RoleType = (RoleTypes)i
                                          });
            }

            context.Users.AddOrUpdate(u => u.Email,
                                      new User()
                                      {
                                          Id = 1,
                                          UserName = "Admin",
                                          Email = "admin@admin.admin",
                                          Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                                          RoleId = (int)RoleTypes.Admin + 1
                                      },
                                      new User()
                                      {
                                          Id = 2,
                                          UserName = "User",
                                          Email = "user@user.user",
                                          Password = "AMv5z9i6ZmvSQzzeZLYJ+xPDXjhKDK+hEoWscrqTIMKyhDhmzMdp/XkP30wP0/wQxA==",
                                          RoleId = (int)RoleTypes.User + 1
                                      });

            var questionTypeNames = Enum.GetNames(typeof(QuestionTypeEnum));
            for (var i = 0; i < questionTypeNames.Length; i++)
            {
                context.QuestionTypes.AddOrUpdate(new QuestionType
                                                  {
                                                      Id = i + 1,
                                                      Name = questionTypeNames[i],
                                                      Type = (QuestionTypeEnum)i
                                                  });
            }

            context.Surveys.AddOrUpdate(s => s.Id,
                                        new Survey()
                                        {
                                            Id = 1,
                                            AuthorId = 1,
                                            Title = "My test survey",
                                            Version = 1,
                                            Created = DateTime.Now,
                                            Updated = DateTime.Now,
                                            SettingsId = 1
                                        });

            context.SurveySettings.AddOrUpdate(new SurveySettings
                                               {
                                                   Id = 1,
                                                   HasPageNumbers = true,
                                                   HasRequiredFieldsStars = true,
                                                   HasQuestionNumbers = true,
                                                   HasProgressIndicator = true,
                                                   IsRandomOrdered = true,
                                                   IsAnonymous = true
                                               });

            context.SurveyPages.AddOrUpdate(sp => sp.Id,
                                            new SurveyPage()
                                            {
                                                Id = 1,
                                                Number = 1,
                                                Title = "First page"
                                            },
                                            new SurveyPage()
                                            {
                                                Id = 2,
                                                Number = 2,
                                                Title = "Second page"
                                            },
                                            new SurveyPage()
                                            {
                                                Id = 3,
                                                Number = 3,
                                                Title = "Third page"
                                            },
                                            new SurveyPage()
                                            {
                                                Id = 4,
                                                Number = 1,
                                                Title = "First template page"
                                            },
                                            new SurveyPage()
                                            {
                                                Id = 5,
                                                Number = 2,
                                                Title = "Second template page"
                                            },
                                            new SurveyPage()
                                            {
                                                Id = 6,
                                                Number = 3,
                                                Title = "Third template page"
                                            });

            context.SurveyLookups.AddOrUpdate(sl => new
                                                    {
                                                        sl.PageId,
                                                        sl.SurveyId,
                                                        sl.SurveyVersion
                                                    },
                                              new SurveyLookup()
                                              {
                                                  PageId = 1,
                                                  SurveyId = 1,
                                                  SurveyVersion = 1
                                              },
                                              new SurveyLookup()
                                              {
                                                  PageId = 2,
                                                  SurveyId = 1,
                                                  SurveyVersion = 1
                                              },
                                              new SurveyLookup()
                                              {
                                                  PageId = 3,
                                                  SurveyId = 1,
                                                  SurveyVersion = 1
                                              });

            context.Questions.AddOrUpdate(q => q.Id,
                                          new Question()
                                          {
                                              Id = 1,
                                              PageId = 1,
                                              QuestionNumber = 1,
                                              Title = "First question",
                                              QuestionTypeId = (int)QuestionTypeEnum.Text + 1,
                                              IsRequired = true,
                                              MetaInfo = ""
                                          },
                                          new Question()
                                          {
                                              Id = 2,
                                              PageId = 2,
                                              QuestionNumber = 2,
                                              Title = "Second question",
                                              QuestionTypeId = (int)QuestionTypeEnum.Text + 1,
                                              IsRequired = true,
                                              MetaInfo = ""
                                          },
                                          new Question()
                                          {
                                              Id = 3,
                                              PageId = 3,
                                              QuestionNumber = 3,
                                              Title = "Third question",
                                              QuestionTypeId = (int)QuestionTypeEnum.Text + 1,
                                              IsRequired = true,
                                              MetaInfo = ""
                                          });

            context.SurveyResponses.AddOrUpdate(sr => sr.Id,
                                                new SurveyResponse()
                                                {
                                                    Id = 1,
                                                    SurveyId = 1,
                                                    SurveyVersion = 1,
                                                    UserId = 2,
                                                    Passed = DateTime.Now
                                                });

            context.QuestionAnswers.AddOrUpdate(qa => new
                                                      {
                                                          qa.QuestionId,
                                                          qa.ReplyOnSurveyId
                                                      },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 1,
                                                    ReplyOnSurveyId = 1,
                                                    Value = "{\"text\":\"Answer 1\"}"
                                                },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 2,
                                                    ReplyOnSurveyId = 1,
                                                    Value = "{\"text\":\"Answer 2\"}"
                                                },
                                                new QuestionAnswer()
                                                {
                                                    QuestionId = 3,
                                                    ReplyOnSurveyId = 1,
                                                    Value = "{\"text\":\"Answer 3\"}"
                                                });

            context.Templates.AddOrUpdate(t => t.Id,
                                          new Template()
                                          {
                                              Id = 1,
                                              Title = "My first template",
                                              Description = "My first template description"
                                          });

            context.TemplateLookups.AddOrUpdate(tl => new
                                                      {
                                                          tl.PageId,
                                                          tl.TemplateId
                                                      },
                                                new TemplateLookup()
                                                {
                                                    TemplateId = 1,
                                                    PageId = 4
                                                },
                                                new TemplateLookup()
                                                {
                                                    TemplateId = 1,
                                                    PageId = 5
                                                },
                                                new TemplateLookup()
                                                {
                                                    TemplateId = 1,
                                                    PageId = 6
                                                });
        }
    }
}