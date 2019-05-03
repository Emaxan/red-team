using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Question");

            Property(q => q.Name).IsRequired();
            Property(q => q.IsRequired).IsRequired();
            Property(q => q.EnableIf).IsRequired();
            Property(q => q.VisibleIf).IsRequired();
            Property(q => q.Visible).IsRequired();
            Property(q => q.StartWithNewLine).IsRequired();

            HasRequired(q => q.Title)
                .WithMany()
                .HasForeignKey(q => q.TitleId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Placeholder)
                .WithMany()
                .HasForeignKey(q => q.PlaceholderId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.MinRateDescription)
                .WithMany()
                .HasForeignKey(q => q.MinRateDescriptionId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.MaxRateDescription)
                .WithMany()
                .HasForeignKey(q => q.MaxRateDescriptionId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.OptionsCaption)
                .WithMany()
                .HasForeignKey(q => q.OptionsCaptionId)
                .WillCascadeOnDelete(false);

            HasMany(q => q.Answers)
                .WithRequired(qa => qa.Question)
                .HasForeignKey(qa => qa.QuestionId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Page)
                .WithMany(p => p.Questions)
                .HasForeignKey(q => q.PageId)
                .WillCascadeOnDelete(false);

            HasRequired(q => q.Type)
                .WithMany(qt => qt.Questions)
                .HasForeignKey(q => q.TypeId)
                .WillCascadeOnDelete(false);

            HasMany(q => q.Choices)
                .WithRequired(qv => qv.Question)
                .HasForeignKey(qv => qv.QuestionId)
                .WillCascadeOnDelete(false);
        }
    }
}