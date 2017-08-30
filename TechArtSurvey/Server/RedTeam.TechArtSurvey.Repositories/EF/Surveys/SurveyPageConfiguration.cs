using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyPageConfiguration : EntityTypeConfiguration<SurveyPage>
    {
        public SurveyPageConfiguration()
        {
            ToTable("SurveyPage");

            Property(sp => sp.Title).IsRequired();
            Property(sp => sp.Number).IsRequired();

            HasMany(sp => sp.Questions)
                .WithRequired(q => q.Page)
                .HasForeignKey(q => q.PageId);

            HasMany(sp => sp.SurveyVersions)
                .WithMany(sv => sv.Pages);

            HasMany(sp => sp.Templates)
                .WithMany(t => t.Pages);
        }
    }
}