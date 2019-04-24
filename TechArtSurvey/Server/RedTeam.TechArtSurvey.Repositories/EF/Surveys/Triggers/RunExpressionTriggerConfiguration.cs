using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Triggers;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Triggers
{
    public class RunExpressionTriggerConfiguration : EntityTypeConfiguration<RunExpressionTrigger>
    {
        public RunExpressionTriggerConfiguration()
        {
            ToTable("RunExpressionTrigger");

            Property(ret => ret.RunExpression).IsRequired();
            Property(ret => ret.SetToName).IsRequired();
        }
    }
}