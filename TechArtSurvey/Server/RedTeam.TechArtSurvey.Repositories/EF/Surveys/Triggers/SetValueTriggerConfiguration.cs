using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Triggers
{
    public class SetValueTriggerConfiguration : EntityTypeConfiguration<SetValueTrigger>
    {
        public SetValueTriggerConfiguration()
        {
            ToTable("SetValueTrigger");

            Property(svt => svt.SetToName).IsRequired();
            Property(svt => svt.SetValue).IsRequired();
        }
    }
}