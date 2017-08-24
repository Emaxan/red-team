using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            ToTable("Survey");

            Property(s => s.Id).IsRequired();
            Property(s => s.Version).IsRequired();
            Property(s => s.Title).IsRequired();
            Property(s => s.Created).IsRequired();
            Property(s => s.Updated).IsRequired();
            Property(s => s.AuthorId).IsRequired();

            HasKey(s => new
                        {
                            s.Id,
                            s.Version
                        });

            HasRequired(s => s.User)
                .WithMany(u => u.Surveys)
                .HasForeignKey(u => u.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(s => s.Settings)
                .WithMany(ss => ss.Surveys)
                .HasForeignKey(s => s.SettingsId)
                .WillCascadeOnDelete(false);

            HasMany(s => s.SurveyResponse)
                .WithRequired(sr => sr.Survey)
                .HasForeignKey(sr => new
                                      {
                                          sr.SurveyId,
                                          sr.SurveyVersion
                                      })
                .WillCascadeOnDelete(false);

            HasMany(s => s.SurveyLookups)
                .WithRequired(sl => sl.Survey)
                .HasForeignKey(sl => new
                                     {
                                         sl.SurveyId,
                                         sl.SurveyVersion
                                     })
                .WillCascadeOnDelete(false);
        }
    }
}