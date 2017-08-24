using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TemplateLookupConfiguration : EntityTypeConfiguration<TemplateLookup>
    {
        public TemplateLookupConfiguration()
        {
            ToTable("TemplateLookup");

            HasKey(tl => new
                         {
                             tl.TemplateId,
                             tl.PageId
                         });

            HasRequired(tl => tl.Template)
                .WithMany(t => t.TemplateLookups)
                .HasForeignKey(tl => tl.TemplateId)
                .WillCascadeOnDelete(false);

            HasRequired(tl => tl.SurveyPage)
                .WithMany(sp => sp.TemplateLookups)
                .HasForeignKey(tl => tl.PageId)
                .WillCascadeOnDelete(false);
        }
    }
}