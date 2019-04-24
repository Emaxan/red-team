using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class DatePickerConfiguration : EntityTypeConfiguration<DatePicker>
    {
        public DatePickerConfiguration()
        {
            ToTable("DatePicker");

            HasRequired(dp => dp.Placeholder)
                .WithMany()
                .HasForeignKey(dp => dp.PlaceholderId)
                .WillCascadeOnDelete(false);
        }
    }
}