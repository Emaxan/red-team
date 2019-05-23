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
        }
    }
}