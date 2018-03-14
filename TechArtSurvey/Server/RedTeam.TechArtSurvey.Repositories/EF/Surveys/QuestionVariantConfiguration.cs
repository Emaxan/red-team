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
            Property(qv => qv.Text).IsRequired();
            Property(qv => qv.UsageStat).IsRequired();

            HasRequired(qv => qv.Question)
                .WithMany(q => q.Variants)
                .HasForeignKey(qv => qv.QuestionId)
                .WillCascadeOnDelete(false);

            HasMany(qv => qv.Answers)
                .WithMany(qa => qa.Variants);
        }
    }
}