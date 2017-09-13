using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyPageConfiguration : EntityTypeConfiguration<SurveyPage>
    {
        public SurveyPageConfiguration()
        {
            ToTable("SurveyPage");

            HasRequired(sp => sp.SurveyVersion)
                .WithMany(sv => sv.Pages)
                .HasForeignKey(sp => sp.SurveyVersionId)
                .WillCascadeOnDelete(false);
        }
    }
}