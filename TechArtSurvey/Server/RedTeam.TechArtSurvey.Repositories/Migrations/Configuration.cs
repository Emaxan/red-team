using System;
using System.Collections.Generic;
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
                                        new Survey
                                        {
                                            Id = 1,
                                            AuthorId = 1,
                                            CreatedDate = DateTime.Now,
                                        });

            var pages = new List<Page>
                        {
                            new SurveyPage
                            {
                                Id = 1,
                                Number = 1,
                                Title = "First page"
                            },
                            new SurveyPage
                            {
                                Id = 2,
                                Number = 2,
                                Title = "Second page"
                            },
                            new SurveyPage
                            {
                                Id = 3,
                                Number = 3,
                                Title = "Third page"
                            },
                            new TemplatePage
                            {
                                Id = 4,
                                Number = 1,
                                Title = "First template page"
                            },
                            new TemplatePage
                            {
                                Id = 5,
                                Number = 2,
                                Title = "Second template page"
                            },
                            new TemplatePage
                            {
                                Id = 6,
                                Number = 3,
                                Title = "Third template page"
                            }
                        };

            pages.ForEach(p => context.Pages.AddOrUpdate(sp => sp.Id, p));

            context.SurveyVersions.AddOrUpdate(sv => sv.Id, 
                                               new SurveyVersion
                                               {
                                                   Id = 1,
                                                   Version = 1,
                                                   Title = "My test survey",
                                                   UpdatedDate = DateTime.Now,
                                                   SurveyId = 1,
                                                   Settings = new SurveySettings
                                                              {
                                                                  HasPageNumbers = true,
                                                                  HasRequiredFieldsStars = true,
                                                                  HasQuestionNumbers = true,
                                                                  HasProgressIndicator = true,
                                                                  IsRandomOrdered = true,
                                                                  IsAnonymous = true
                                                              },
                                                   Pages = new List<SurveyPage>
                                                           {
                                                               pages[0] as SurveyPage,
                                                               pages[1] as SurveyPage,
                                                               pages[2] as SurveyPage
                                                           }
                                               });

            var questionVariants = new List<QuestionVariant>
                                   {
                                       new QuestionVariant
                                       {
                                           Id = 1,
                                           Text = "Option 1",
                                           QuestionId = 2
                                       },
                                       new QuestionVariant
                                       {
                                           Id = 2,
                                           Text = "Option 2",
                                           QuestionId = 2
                                       },
                                       new QuestionVariant
                                       {
                                           Id = 3,
                                           Text = "Option 3",
                                           QuestionId = 2
                                       },
                                   };

            context.Questions.AddOrUpdate(q => q.Id,
                                          new Question
                                          {
                                              Id = 1,
                                              PageId = 1,
                                              Number = 1,
                                              Title = "First question",
                                              Default = "First question",
                                              TypeId = (int)QuestionTypeEnum.Text + 1,
                                              IsRequired = true,
                                              Variants = new List<QuestionVariant>()
                                          },
                                          new Question
                                          {
                                              Id = 2,
                                              PageId = 2,
                                              Number = 2,
                                              Title = "Second question",
                                              Default = null,
                                              TypeId = (int)QuestionTypeEnum.Multi + 1,
                                              IsRequired = true,
                                              Variants = questionVariants
                                          },
                                          new Question
                                          {
                                              Id = 3,
                                              PageId = 3,
                                              Number = 3,
                                              Title = "Third question",
                                              Default = "Third question",
                                              TypeId = (int)QuestionTypeEnum.Text + 1,
                                              IsRequired = true,
                                              Variants = new List<QuestionVariant>()
                                          });

            questionVariants.ForEach(qv => context.QuestionVariants.AddOrUpdate(qv));

            context.SurveyResponses.AddOrUpdate(sr => sr.Id,
                                                new SurveyResponse
                                                {
                                                    Id = 1,
                                                    SurveyVersionId = 1,
                                                    UserId = 2,
                                                    PassedDate = DateTime.Now
                                                });

            context.QuestionAnswers.AddOrUpdate(qa => new
                                                      {
                                                          qa.QuestionId,
                                                          qa.SurveyResponseId
                                                      },
                                                new QuestionAnswer
                                                {
                                                    QuestionId = 1,
                                                    SurveyResponseId = 1,
                                                    Value = "Answer 1"
                                                },
                                                new QuestionAnswer
                                                {
                                                    QuestionId = 2,
                                                    SurveyResponseId = 1,
                                                    Value = "Answer 2"
                                                },
                                                new QuestionAnswer
                                                {
                                                    QuestionId = 3,
                                                    SurveyResponseId = 1,
                                                    Value = "Answer 3"
                                                });

            context.Templates.AddOrUpdate(t => t.Id,
                                          new SurveyTemplate
                                          {
                                              Id = 1,
                                              Title = "My first template",
                                              Description = "My first template description",
                                              Pages = new List<TemplatePage>
                                                      {
                                                          pages[3] as TemplatePage,
                                                          pages[4] as TemplatePage,
                                                          pages[5] as TemplatePage
                                                      }
                                          });
        }
    }
}