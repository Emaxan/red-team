using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Question");

            Property(q => q.Title).IsRequired();
            Property(q => q.QuestionTypeId).IsRequired();
            Property(q => q.QuestionNumber).IsRequired();
            Property(q => q.IsRequired).IsRequired();
            Property(q => q.MetaInfo).IsRequired();

            HasMany(q => q.QuestionAnswers)
                .WithRequired(qa => qa.Question)
                .HasForeignKey(qa => qa.QuestionId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Page)
                .WithMany(sp => sp.Questions)
                .HasForeignKey(q => q.PageId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.QuestionType)
                .WithMany(qt => qt.Questions)
                .HasForeignKey(q => q.QuestionTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}