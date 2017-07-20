using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using JetBrains.Annotations;

using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    [UsedImplicitly]
    public class TechArtSurveyContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }


        public TechArtSurveyContext()
        {
        }

        public TechArtSurveyContext(string connectionString)
            : base(connectionString)
        {
        }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<User>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(u => u.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            modelBuilder.Entity<User>().Property(u => u.Email)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}