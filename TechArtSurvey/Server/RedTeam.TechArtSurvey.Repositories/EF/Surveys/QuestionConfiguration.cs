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
            Property(q => q.TypeId).IsRequired();
            Property(q => q.Number).IsRequired();
            Property(q => q.IsRequired).IsRequired();
            Property(q => q.Default).IsOptional();

            HasMany(q => q.Answers)
                .WithRequired(qa => qa.Question)
                .HasForeignKey(qa => qa.QuestionId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Page)
                .WithMany(p => p.Questions)
                .HasForeignKey(q => q.PageId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Type)
                .WithMany(qt => qt.Questions)
                .HasForeignKey(q => q.TypeId)
                .WillCascadeOnDelete(false);

            HasMany(q => q.Variants)
                .WithRequired(qv => qv.Question)
                .HasForeignKey(qv => qv.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}