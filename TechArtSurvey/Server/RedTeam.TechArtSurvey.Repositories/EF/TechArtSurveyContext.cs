using System.Data.Entity;
using JetBrains.Annotations;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Repositories.EF.Surveys;
using RedTeam.TechArtSurvey.Repositories.EF.Surveys.Questions;
using RedTeam.TechArtSurvey.Repositories.EF.Surveys.Triggers;
using RedTeam.TechArtSurvey.Repositories.EF.Users;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    [UsedImplicitly]
    public class TechArtSurveyContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<SurveyVersion> SurveyVersions { get; set; }

        public DbSet<QuestionVariant> QuestionVariants { get; set; }

        public DbSet<SurveyTemplate> Templates { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<LocalizableString> LocalizableStrings { get; set; }


        public TechArtSurveyContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public TechArtSurveyContext(string connectionString)
            : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new QuestionAnswerConfiguration());
            modelBuilder.Configurations.Add(new SurveyResponseConfiguration());
            modelBuilder.Configurations.Add(new SurveyConfiguration());
            modelBuilder.Configurations.Add(new SurveyVersionConfiguration());
            modelBuilder.Configurations.Add(new SurveyPageConfiguration());
            modelBuilder.Configurations.Add(new TemplatePageConfiguration());
            modelBuilder.Configurations.Add(new PageConfiguration());
            modelBuilder.Configurations.Add(new TemplateConfiguration());
            modelBuilder.Configurations.Add(new QuestionVariantConfiguration());
            modelBuilder.Configurations.Add(new QuestionTypeConfiguration());
            modelBuilder.Configurations.Add(new LocalizableStringConfiguration());
            modelBuilder.Configurations.Add(new TextAreaConfiguration());
            modelBuilder.Configurations.Add(new TextConfiguration());
            modelBuilder.Configurations.Add(new MatrixColConfiguration());
            modelBuilder.Configurations.Add(new MatrixRowConfiguration());
            modelBuilder.Configurations.Add(new MatrixConfiguration());
            modelBuilder.Configurations.Add(new DropdownConfiguration());
            modelBuilder.Configurations.Add(new DatePickerConfiguration());
            modelBuilder.Configurations.Add(new CheckboxConfiguration());
            modelBuilder.Configurations.Add(new BooleanConfiguration());
            modelBuilder.Configurations.Add(new BarRatingConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
            modelBuilder.Configurations.Add(new RadioGroupConfiguration());
            modelBuilder.Configurations.Add(new TriggerConfiguration());
            modelBuilder.Configurations.Add(new VisibleTriggerConfiguration());
            modelBuilder.Configurations.Add(new RunExpressionTriggerConfiguration());
            modelBuilder.Configurations.Add(new SetValueTriggerConfiguration());
            modelBuilder.Configurations.Add(new CopyValueTriggerConfiguration());
            base.OnModelCreating(modelBuilder);
        }  
    }
}