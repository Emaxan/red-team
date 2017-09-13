using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TemplateConfiguration : EntityTypeConfiguration<SurveyTemplate>
    {
        public TemplateConfiguration()
        {
            ToTable("SurveyTemplate");

            Property(t => t.Title).IsRequired();
            Property(t => t.Description).IsRequired();

            HasMany(t => t.Pages)
                .WithRequired(tp => tp.Template)
                .HasForeignKey(tp => tp.TemplateId)
                .WillCascadeOnDelete(false);
        }
    }
}