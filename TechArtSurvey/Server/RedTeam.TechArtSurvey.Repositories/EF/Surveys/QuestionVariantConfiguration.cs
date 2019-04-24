using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class QuestionVariantConfiguration : EntityTypeConfiguration<QuestionVariant>
    {
        public QuestionVariantConfiguration()
        {
            ToTable("QuestionVariant");

            Property(qv => qv.QuestionId).IsRequired();
            Property(qv => qv.UsageStat).IsRequired();
            Property(qv => qv.Value).IsRequired();
            Property(qv => qv.VisibleIf).IsRequired();
            Property(qv => qv.EnableIf).IsRequired();

            HasRequired(qv => qv.Text)
                .WithMany()
                .HasForeignKey(qv => qv.TextId)
                .WillCascadeOnDelete(false);

            HasRequired(qv => qv.Question)
                .WithMany(q => q.Choices)
                .HasForeignKey(qv => qv.QuestionId)
                .WillCascadeOnDelete(false);

            HasMany(qv => qv.Answers)
                .WithMany(qa => qa.Variants);
        }
    }
}