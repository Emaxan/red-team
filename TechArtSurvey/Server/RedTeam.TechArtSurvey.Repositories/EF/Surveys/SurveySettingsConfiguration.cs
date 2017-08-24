using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveySettingsConfiguration : EntityTypeConfiguration<SurveySettings>
    {
        public SurveySettingsConfiguration()
        {
            ToTable("SurveySettings");

            Property(ss => ss.Id).IsRequired();
            Property(ss => ss.HasPageNumbers).IsRequired();
            Property(ss => ss.HasProgressIndicator).IsRequired();
            Property(ss => ss.HasQuestionNumbers).IsRequired();
            Property(ss => ss.HasRequiredFieldsStars).IsRequired();
            Property(ss => ss.IsAnonymous).IsRequired();
            Property(ss => ss.IsRandomOrdered).IsRequired();

            HasMany(ss => ss.Surveys)
                .WithRequired(s => s.Settings)
                .HasForeignKey(s => s.SettingsId)
                .WillCascadeOnDelete(false);
        }
    }
}