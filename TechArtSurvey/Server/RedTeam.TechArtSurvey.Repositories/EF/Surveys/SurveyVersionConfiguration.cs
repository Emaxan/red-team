using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.EF.Surveys
{
    public class SurveyVersionConfiguration : EntityTypeConfiguration<SurveyVersion>
    {
        public SurveyVersionConfiguration()
        {
            ToTable("SurveyVersion");

            Property(sv => sv.Id).IsRequired();
            Property(sv => sv.Number).IsRequired();
            Property(sv => sv.CreatedDate).IsRequired();
            Property(sv => sv.SurveyId).IsRequired();
            Property(sv => sv.StartDate).IsRequired();
            Property(sv => sv.EndDate).IsRequired();

            Property(sv => sv.Settings.Locale).HasColumnName("Locale").IsRequired();
            Property(sv => sv.Settings.ShowCompletedPage).HasColumnName("ShowCompletedPage").IsRequired();
            Property(sv => sv.Settings.ShowPageNumbers).HasColumnName("ShowPageNumbers").IsRequired();
            Property(sv => sv.Settings.ShowPrevButton).HasColumnName("ShowPrevButton").IsRequired();
            Property(sv => sv.Settings.GoNextPageAutomatic).HasColumnName("GoNextPageAutomatic").IsRequired();
            Property(sv => sv.Settings.FirstPageIsStarted).HasColumnName("FirstPageIsStarted").IsRequired();
            Property(sv => sv.Settings.IsSinglePage).HasColumnName("IsSinglePage").IsRequired();
            Property(sv => sv.Settings.RequiredText).HasColumnName("RequiredText").IsRequired();
            Property(sv => sv.Settings.MaxTimeToFinish).HasColumnName("MaxTimeToFinish").IsRequired();
            Property(sv => sv.Settings.MaxTimeToFinishPage).HasColumnName("MaxTimeToFinishPage").IsRequired();
            Property(sv => sv.Settings.ShowNavigationButtons).HasColumnName("ShowNavigationButtons").IsRequired();
            Property(sv => sv.Settings.QuestionTitleLocation).HasColumnName("QuestionTitleLocation").IsRequired();
            Property(sv => sv.Settings.QuestionErrorLocation).HasColumnName("QuestionErrorLocation").IsRequired();
            Property(sv => sv.Settings.ShowProgressBar).HasColumnName("ShowProgressBar").IsRequired();
            Property(sv => sv.Settings.ShowTimerPanel).HasColumnName("ShowTimerPanel").IsRequired();
            Property(sv => sv.Settings.QuestionsOrder).HasColumnName("QuestionsOrder").IsRequired();
            Property(sv => sv.Settings.ShowQuestionNumbers).HasColumnName("ShowQuestionNumbers").IsRequired();
            Property(sv => sv.Settings.ShowTimerPanelMode).HasColumnName("ShowTimerPanelMode").IsRequired();

            HasRequired(sv => sv.CompletedHtml)
                .WithMany()
                .HasForeignKey(sv => sv.CompletedHtmlId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.StartSurveyText)
                .WithMany()
                .HasForeignKey(sv => sv.StartSurveyTextId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.PagePrevText)
                .WithMany()
                .HasForeignKey(sv => sv.PagePrevTextId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.PageNextText)
                .WithMany()
                .HasForeignKey(sv => sv.PageNextTextId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.CompleteText)
                .WithMany()
                .HasForeignKey(sv => sv.CompleteTextId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.Title)
                .WithMany()
                .HasForeignKey(sv => sv.TitleId)
                .WillCascadeOnDelete(false);

            HasRequired(sv => sv.Survey)
                .WithMany(s => s.Versions)
                .HasForeignKey(sv => sv.SurveyId)
                .WillCascadeOnDelete(false);

            HasMany(sv => sv.Responses)
                .WithRequired(sr => sr.SurveyVersion)
                .HasForeignKey(sr => sr.SurveyVersionId)
                .WillCascadeOnDelete(false);

            HasMany(sv => sv.Pages)
                .WithRequired(sp => sp.SurveyVersion)
                .HasForeignKey(sp => sp.SurveyVersionId)
                .WillCascadeOnDelete(false);

            HasMany(sv => sv.Triggers)
                .WithRequired()
                .WillCascadeOnDelete(false);
        }
    }}