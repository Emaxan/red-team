using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            ToTable("Rating");

            Property(r => r.Rows).IsRequired();

            HasRequired(r => r.MaxRateDescription)
                .WithMany()
                .HasForeignKey(r => r.MaxRateDescriptionId)
                .WillCascadeOnDelete(false);

            HasRequired(r => r.MinRateDescription)
                .WithMany()
                .HasForeignKey(r => r.MinRateDescriptionId)
                .WillCascadeOnDelete(false);
        }
    }
}