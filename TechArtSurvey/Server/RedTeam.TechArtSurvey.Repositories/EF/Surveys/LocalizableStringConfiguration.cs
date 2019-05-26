using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class LocalizableStringConfiguration : EntityTypeConfiguration<LocalizableString>
    {
        public LocalizableStringConfiguration()
        {
            ToTable("LocalizableString");

            HasKey(ls => ls.StringId);

            Property(ls => ls.Default).IsRequired();
        }
    }
}