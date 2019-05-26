using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyTemplateConfiguration : EntityTypeConfiguration<SurveyTemplate>
    {
        public SurveyTemplateConfiguration()
        {
            ToTable("SurveyVersion");

            Property(st => st.Id).IsRequired();
            Property(st => st.CreatedDate).IsRequired();

            Property(st => st.Settings.Locale).HasColumnName("Locale").IsRequired();
            Property(st => st.Settings.ShowCompletedPage).HasColumnName("ShowCompletedPage").IsRequired();
            Property(st => st.Settings.ShowPageNumbers).HasColumnName("ShowPageNumbers").IsRequired();
            Property(st => st.Settings.ShowPrevButton).HasColumnName("ShowPrevButton").IsRequired();
            Property(st => st.Settings.GoNextPageAutomatic).HasColumnName("GoNextPageAutomatic").IsRequired();
            Property(st => st.Settings.FirstPageIsStarted).HasColumnName("FirstPageIsStarted").IsRequired();
            Property(st => st.Settings.IsSinglePage).HasColumnName("IsSinglePage").IsRequired();
            Property(st => st.Settings.RequiredText).HasColumnName("RequiredText").IsRequired();
            Property(st => st.Settings.MaxTimeToFinish).HasColumnName("MaxTimeToFinish").IsRequired();
            Property(st => st.Settings.MaxTimeToFinishPage).HasColumnName("MaxTimeToFinishPage").IsRequired();
            Property(st => st.Settings.ShowNavigationButtons).HasColumnName("ShowNavigationButtons").IsRequired();
            Property(st => st.Settings.QuestionTitleLocation).HasColumnName("QuestionTitleLocation").IsRequired();
            Property(st => st.Settings.QuestionErrorLocation).HasColumnName("QuestionErrorLocation").IsRequired();
            Property(st => st.Settings.ShowProgressBar).HasColumnName("ShowProgressBar").IsRequired();
            Property(st => st.Settings.ShowTimerPanel).HasColumnName("ShowTimerPanel").IsRequired();
            Property(st => st.Settings.QuestionsOrder).HasColumnName("QuestionsOrder").IsRequired();
            Property(st => st.Settings.ShowQuestionNumbers).HasColumnName("ShowQuestionNumbers").IsRequired();
            Property(st => st.Settings.ShowTimerPanelMode).HasColumnName("ShowTimerPanelMode").IsRequired();

            HasRequired(st => st.CompletedHtml)
                .WithMany()
                .HasForeignKey(st => st.CompletedHtmlId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.StartSurveyText)
                .WithMany()
                .HasForeignKey(st => st.StartSurveyTextId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.PagePrevText)
                .WithMany()
                .HasForeignKey(st => st.PagePrevTextId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.PageNextText)
                .WithMany()
                .HasForeignKey(st => st.PageNextTextId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.CompleteText)
                .WithMany()
                .HasForeignKey(st => st.CompleteTextId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.Title)
                .WithMany()
                .HasForeignKey(st => st.TitleId)
                .WillCascadeOnDelete(false);

            HasRequired(st => st.Author)
                .WithMany(u => u.SurveyTemplates)
                .HasForeignKey(st => st.AuthorId)
                .WillCascadeOnDelete(false);

            HasMany(st => st.Triggers)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }
}