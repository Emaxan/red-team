using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Triggers
{
    public class CopyValueTriggerConfiguration : EntityTypeConfiguration<CopyValueTrigger>
    {
        public CopyValueTriggerConfiguration()
        {
            ToTable("CopyValueTrigger");

            Property(cvt => cvt.FromName).IsRequired();
            Property(cvt => cvt.SetToName).IsRequired();
        }
    }
}