using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class TextAreaConfiguration : EntityTypeConfiguration<TextArea>
    {
        public TextAreaConfiguration()
        {
            ToTable("TextArea");

            Property(ta => ta.Rows).IsRequired();

            HasRequired(ta => ta.Placeholder)
                .WithMany()
                .HasForeignKey(ta => ta.PlaceholderId)
                .WillCascadeOnDelete(false);
        }
    }
}