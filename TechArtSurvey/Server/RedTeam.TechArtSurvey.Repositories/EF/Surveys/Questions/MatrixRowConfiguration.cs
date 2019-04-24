using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class MatrixRowConfiguration : EntityTypeConfiguration<MatrixRow>
    {
        public MatrixRowConfiguration()
        {
            ToTable("MatrixRow");

            Property(mr => mr.Id).IsRequired();
            Property(mr => mr.Value).IsRequired();
            Property(mr => mr.VisibleIf).IsRequired();

            HasRequired(mr => mr.Text)
                .WithMany()
                .HasForeignKey(mr => mr.TextId)
                .WillCascadeOnDelete(false);

            HasRequired(mr => mr.Matrix)
                .WithMany(m => m.MatrixRows)
                .HasForeignKey(mr => mr.MatrixId)
                .WillCascadeOnDelete(false);
        }
    }
}