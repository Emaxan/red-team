using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class BarRatingConfiguration : EntityTypeConfiguration<BarRating>
    {
        public BarRatingConfiguration()
        {
            ToTable("BarRating");

            Property(br => br.ChoicesOrder).IsRequired();
        }
    }
}