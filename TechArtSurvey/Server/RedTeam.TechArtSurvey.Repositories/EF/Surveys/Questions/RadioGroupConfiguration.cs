using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class RadioGroupConfiguration : EntityTypeConfiguration<RadioGroup>
    {
        public RadioGroupConfiguration()
        {
            ToTable("RadioGroup");

            Property(rg => rg.HasOther).IsRequired();
            Property(rg => rg.ChoicesOrder).IsRequired();
            Property(c => c.ColCount).IsRequired();
        }
    }
}