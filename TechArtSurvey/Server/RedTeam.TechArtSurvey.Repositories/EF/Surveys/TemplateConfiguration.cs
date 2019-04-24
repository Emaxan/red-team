using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TemplateConfiguration : EntityTypeConfiguration<SurveyTemplate>
    {
        public TemplateConfiguration()
        {
            ToTable("SurveyTemplate");

            HasRequired(t => t.Description)
                .WithMany()
                .HasForeignKey(t => t.DescriptionId)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Title)
                .WithMany()
                .HasForeignKey(t => t.TitleId)
                .WillCascadeOnDelete(false);

            HasMany(t => t.Pages)
                .WithRequired(tp => tp.Template)
                .HasForeignKey(tp => tp.TemplateId)
                .WillCascadeOnDelete(false);
        }
    }
}