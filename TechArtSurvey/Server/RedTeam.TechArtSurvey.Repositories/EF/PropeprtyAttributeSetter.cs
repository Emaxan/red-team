using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    public class PropertyAttributeSetter
    {
        DbModelBuilder _modelBuilder;
        public PropertyAttributeSetter(DbModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void SetupPropertiesAttributes()
        {
            SetupUserPropertiesAttributes();
            SetupTokenPropertiesAttributes();
        }
        private void SetupUserPropertiesAttributes()
        {
            _modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();
            _modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            _modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            _modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            _modelBuilder.Entity<User>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            _modelBuilder.Entity<User>().HasKey(u => u.Id);

            _modelBuilder.Entity<User>().Property(u => u.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            _modelBuilder.Entity<User>().Property(u => u.Email)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }));
        }
        private void SetupTokenPropertiesAttributes()
        {
            _modelBuilder.Entity<Token>().Property(u => u.Id).IsRequired();
            _modelBuilder.Entity<Token>().Property(u => u.Since).IsRequired();
            _modelBuilder.Entity<Token>().Property(u => u.UserId).IsRequired();

            _modelBuilder.Entity<Token>().Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            _modelBuilder.Entity<Token>().HasKey(u => u.Id);
        }
    }
}
