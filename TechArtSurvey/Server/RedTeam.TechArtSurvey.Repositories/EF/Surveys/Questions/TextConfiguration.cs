using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class TextConfiguration : EntityTypeConfiguration<Text>
    {
        public TextConfiguration()
        {
            ToTable("Text");

            HasRequired(t => t.Placeholder)
                .WithMany()
                .HasForeignKey(t => t.PlaceholderId)
                .WillCascadeOnDelete(false);
        }
    }
}