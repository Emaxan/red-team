using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TemplateConfiguration : EntityTypeConfiguration<Template>
    {
        public TemplateConfiguration()
        {
            ToTable("Template");

            Property(t => t.Title).IsRequired();
            Property(t => t.Description).IsRequired();

            HasMany(t => t.Pages)
                .WithMany(sp => sp.Templates);
        }
    }
}