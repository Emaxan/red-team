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
            SetupRolePropertiesAttributes();
            SetupUserPropertiesAttributes();
        }
        private void SetupRolePropertiesAttributes()
        {
            _modelBuilder.Entity<Role>().Property(r => r.Id).IsRequired();
            _modelBuilder.Entity<Role>().Ignore(r => r.Name);
            _modelBuilder.Entity<Role>().Property(r => r.RoleName).IsRequired();

            _modelBuilder.Entity<Role>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            _modelBuilder.Entity<Role>().HasKey(r => r.Id);
        }
        private void SetupUserPropertiesAttributes()
        {
            _modelBuilder.Entity<User>().Property(u => u.Id).IsRequired();
            _modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired();
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
       
    }
}
