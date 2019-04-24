using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class PageConfiguration : EntityTypeConfiguration<Page>
    {
        public PageConfiguration()
        {
            ToTable("Page");

            Property(p => p.Name).IsRequired();
            Property(p => p.VisibleIf).IsRequired();
            Property(p => p.Visible).IsRequired();
            Property(p => p.QuestionsOrder).IsRequired();

            HasRequired(p => p.Title)
                .WithMany()
                .HasForeignKey(p => p.TitleId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Questions)
                .WithRequired(q => q.Page)
                .HasForeignKey(q => q.PageId)
                .WillCascadeOnDelete(false);
        }
    }
}