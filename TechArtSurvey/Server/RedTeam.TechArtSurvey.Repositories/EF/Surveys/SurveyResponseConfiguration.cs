using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyResponseConfiguration : EntityTypeConfiguration<SurveyResponse>
    {
        public SurveyResponseConfiguration()
        {
            ToTable("SurveyResponse");

            Property(sr => sr.PassedDate).IsRequired();
            Property(sr => sr.SurveyVersionId).IsRequired();
            Property(sr => sr.UserId).IsRequired();

            HasRequired(sr => sr.SurveyVersion)
                .WithMany(sv => sv.Responses)
                .HasForeignKey(sr => sr.SurveyVersionId);

            HasRequired(sr => sr.User)
                .WithMany(u => u.SurveyResponses)
                .HasForeignKey(sr => sr.UserId)
                .WillCascadeOnDelete(false);

            HasMany(sr => sr.Answers)
                .WithRequired(qa => qa.SurveyResponse)
                .HasForeignKey(qa => qa.SurveyResponseId)
                .WillCascadeOnDelete(false);
        }
    }
}