using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            ToTable("Survey");

            Property(s => s.Id).IsRequired();
            Property(s => s.AuthorId).IsRequired();

            HasRequired(s => s.Author)
                .WithMany(u => u.Surveys)
                .HasForeignKey(u => u.AuthorId)
                .WillCascadeOnDelete(false);

            HasMany(s => s.Versions)
                .WithRequired(sv => sv.Survey)
                .HasForeignKey(sv => sv.SurveyId)
                .WillCascadeOnDelete(false);
        }
    }
}