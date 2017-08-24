using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class QuestionTypeConfiguration : EntityTypeConfiguration<QuestionType>
    {
        public QuestionTypeConfiguration()
        {
            ToTable("QuestionType");

            Property(qt => qt.Id).IsRequired();
            Property(qt => qt.Name).IsRequired();
            Property(qt => qt.Type).IsRequired();

            HasMany(qt => qt.Questions)
                .WithRequired(q => q.QuestionType)
                .HasForeignKey(q => q.QuestionTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}