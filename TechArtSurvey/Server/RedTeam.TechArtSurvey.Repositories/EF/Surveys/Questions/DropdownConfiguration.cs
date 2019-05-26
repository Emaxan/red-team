using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class DropdownConfiguration : EntityTypeConfiguration<Dropdown>
    {
        public DropdownConfiguration()
        {
            ToTable("Dropdown");

            Property(d => d.HasOther).IsRequired();
            Property(d => d.ChoicesOrder).IsRequired();
        }
    }
}