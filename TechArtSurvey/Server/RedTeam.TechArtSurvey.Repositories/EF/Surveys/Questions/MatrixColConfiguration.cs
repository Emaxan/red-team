using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class MatrixColConfiguration : EntityTypeConfiguration<MatrixCol>
    {
        public MatrixColConfiguration()
        {
            ToTable("MatrixCol");

            Property(mc => mc.Id).IsRequired();
            Property(mc => mc.Value).IsRequired();
            Property(mc => mc.VisibleIf).IsRequired();

            HasRequired(mc => mc.Text)
                .WithMany()
                .HasForeignKey(mc => mc.TextId)
                .WillCascadeOnDelete(false);

            HasRequired(mc => mc.Question)
                .WithMany(m => m.MatrixCols)
                .HasForeignKey(mc => mc.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}