using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Repositories.EF.Users
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.UserName).IsRequired();
            Property(u => u.Email).IsRequired();
            Property(u => u.Password).IsRequired();
            HasRequired(u => u.Role)
                    .WithMany(u => u.Users)
                    .HasForeignKey(u => u.RoleId);

            Property(u => u.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            Property(u => u.Email)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }));
        }
    }
}