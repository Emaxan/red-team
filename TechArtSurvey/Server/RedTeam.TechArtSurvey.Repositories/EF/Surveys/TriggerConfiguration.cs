using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class TriggerConfiguration : EntityTypeConfiguration<Trigger>
    {
        public TriggerConfiguration()
        {
            ToTable("Trigger");

            Property(t => t.Id).IsRequired();
            Property(t => t.Type).IsRequired();
            Property(t => t.Expression).IsRequired();
        }
    }
}