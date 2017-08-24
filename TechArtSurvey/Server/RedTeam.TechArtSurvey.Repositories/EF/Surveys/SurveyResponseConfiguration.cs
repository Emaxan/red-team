using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyResponseConfiguration : EntityTypeConfiguration<SurveyResponse>
    {
        public SurveyResponseConfiguration()
        {
            ToTable("SurveyResponse");

            Property(sr => sr.Passed).IsRequired();
            Property(sr => sr.SurveyVersion).IsRequired();
            Property(sr => sr.UserId).IsRequired();

            HasRequired(sr => sr.Survey)
                .WithMany(s => s.SurveyResponse)
                .HasForeignKey(sr => new
                                      {
                                          sr.SurveyId,
                                          sr.SurveyVersion
                                      });

            HasRequired(sr => sr.User)
                .WithMany(u => u.SurveyResponses)
                .HasForeignKey(sr => sr.UserId)
                .WillCascadeOnDelete(false);

            HasMany(sr => sr.QuestionAnswers)
                .WithRequired(qa => qa.SurveyResponse)
                .HasForeignKey(qa => qa.ReplyOnSurveyId)
                .WillCascadeOnDelete(false);
        }
    }
}