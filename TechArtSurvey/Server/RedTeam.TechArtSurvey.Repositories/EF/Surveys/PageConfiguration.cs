using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class PageConfiguration : EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            ToTable("Page");

            Property(sp => sp.Title).IsRequired();
            Property(sp => sp.Number).IsRequired();

            HasMany(sp => sp.Questions)
                .WithRequired(q => q.Page)
                .HasForeignKey(q => q.PageId)
                .WillCascadeOnDelete(false);
        }
    }
}