using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class QuestionAnswerConfiguration : EntityTypeConfiguration<QuestionAnswer>
    {
        public QuestionAnswerConfiguration()
        {
            ToTable("QuestionAnswer");

            Property(qa => qa.Value).IsRequired();

            HasKey(qa => new
                          {
                              qa.SurveyResponseId,
                              qa.QuestionId
                          });

            HasRequired(qa => qa.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(qa => qa.QuestionId)
                .WillCascadeOnDelete(false);

            HasRequired(qa => qa.SurveyResponse)
                .WithMany(sr => sr.Answers)
                .HasForeignKey(qa => qa.SurveyResponseId)
                .WillCascadeOnDelete(false);

            HasMany(qa => qa.Variants)
                .WithMany(qv => qv.Answers);
        }
    }
}