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
                              qa.ReplyOnSurveyId,
                              qa.QuestionId
                          });

            HasRequired(qa => qa.Question)
                .WithMany(q => q.QuestionAnswers)
                .HasForeignKey(qa => qa.QuestionId)
                .WillCascadeOnDelete(false);

            HasRequired(qa => qa.SurveyResponse)
                .WithMany(sr => sr.QuestionAnswers)
                .HasForeignKey(qa => qa.ReplyOnSurveyId)
                .WillCascadeOnDelete(false);
        }
    }
}