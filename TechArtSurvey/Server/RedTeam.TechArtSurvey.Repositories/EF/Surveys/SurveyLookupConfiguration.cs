using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyLookupConfiguration : EntityTypeConfiguration<SurveyLookup>
    {
        public SurveyLookupConfiguration()
        {
            ToTable("SurveyLookup");

            Property(sl => sl.SurveyVersion).IsRequired();

            HasKey(sl => new
                         {
                            sl.SurveyId,
                            sl.PageId,
                            sl.SurveyVersion
                         });

            HasRequired(sl => sl.Page)
                .WithMany(sp => sp.SurveyLookups)
                .HasForeignKey(sl => sl.PageId)
                .WillCascadeOnDelete(false);

            HasRequired(sl => sl.Survey)
                .WithMany(s => s.Lookups)
                .HasForeignKey(sl => new
                                     {
                                         sl.SurveyId,
                                         sl.SurveyVersion
                                     })
                .WillCascadeOnDelete(false);
        }
    }
}