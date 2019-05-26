using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Triggers
{
    public class VisibleTriggerConfiguration : EntityTypeConfiguration<VisibleTrigger>
    {
        public VisibleTriggerConfiguration()
        {
            ToTable("VisibleTrigger");

            HasMany(vt => vt.Pages)
                .WithMany(p => p.VisibleTriggers);

            HasMany(vt => vt.Questions)
                .WithMany(q => q.VisibleTriggers);
        }
    }
}