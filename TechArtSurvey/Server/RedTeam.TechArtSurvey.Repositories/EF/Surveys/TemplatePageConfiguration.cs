using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TemplatePageConfiguration : EntityTypeConfiguration<TemplatePage>
    {
        public TemplatePageConfiguration()
        {
            ToTable("TemplatePage");

            HasRequired(tp => tp.Template)
                .WithMany(st => st.Pages)
                .HasForeignKey(tp => tp.TemplateId)
                .WillCascadeOnDelete(false);
        }
    }
}