using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class BooleanConfiguration : EntityTypeConfiguration<Boolean>
    {
        public BooleanConfiguration()
        {
            ToTable("Boolean");

            HasRequired(b => b.Label)
                .WithMany()
                .HasForeignKey(b => b.LabelId)
                .WillCascadeOnDelete(false);
        }
    }
}