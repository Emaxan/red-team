using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions
{
    public class CheckboxConfiguration : EntityTypeConfiguration<Checkbox>
    {
        public CheckboxConfiguration()
        {
            ToTable("Checkbox");

            Property(c => c.HasOther).IsRequired();
            Property(c => c.ChoicesOrder).IsRequired();

            HasRequired(c => c.OtherText)
                .WithMany()
                .HasForeignKey(c => c.OtherTextId)
                .WillCascadeOnDelete(false);
        }
    }
}