using System.Data.Entity;
using JetBrains.Annotations;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Repositories.EF.Surveys;
using RedTeam.TechArtSurvey.Repositories.EF.Users;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    [UsedImplicitly]
    public class TechArtSurveyContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<SurveyPage> SurveyPages { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        public DbSet<SurveyVersion> SurveyVersions { get; set; }

        public DbSet<QuestionVariant> QuestionVariants { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }


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
            modelBuilder.Configurations.Add(new TemplateConfiguration());
            modelBuilder.Configurations.Add(new QuestionVariantConfiguration());
            modelBuilder.Configurations.Add(new QuestionTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }  
    }
}