using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyVersionConfiguration : EntityTypeConfiguration<SurveyVersion>
    {
        public SurveyVersionConfiguration()
        {
            ToTable("SurveyVersion");

            Property(sv => sv.Version).IsRequired();
            Property(sv => sv.Title).IsRequired();
            Property(sv => sv.UpdatedDate).IsRequired();
            Property(sv => sv.SurveyId).IsRequired();

            Property(sv => sv.Settings.HasPageNumbers).HasColumnName("HasPageNumbers").IsRequired();
            Property(sv => sv.Settings.HasProgressIndicator).HasColumnName("HasProgressIndicator").IsRequired();
            Property(sv => sv.Settings.HasQuestionNumbers).HasColumnName("HasQuestionNumbers").IsRequired();
            Property(sv => sv.Settings.HasRequiredFieldsStars).HasColumnName("HasRequiredFieldsStars").IsRequired();
            Property(sv => sv.Settings.IsAnonymous).HasColumnName("IsAnonymous").IsRequired();
            Property(sv => sv.Settings.IsRandomOrdered).HasColumnName("IsRandomOrdered").IsRequired();

            HasRequired(sv => sv.Survey)
                .WithMany(sv => sv.Versions)
                .HasForeignKey(sv => sv.SurveyId)
                .WillCascadeOnDelete(false);

            HasMany(sv => sv.Responses)
                .WithRequired(sr => sr.SurveyVersion)
                .HasForeignKey(sr => sr.SurveyVersionId)
                .WillCascadeOnDelete(false);

            HasMany(sv => sv.Pages)
                .WithMany(sp => sp.SurveyVersions);
        }
    }
}