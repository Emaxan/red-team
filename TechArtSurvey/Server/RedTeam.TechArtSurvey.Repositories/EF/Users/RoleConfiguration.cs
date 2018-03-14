using System.Data.Entity.ModelConfiguration;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Repositories.EF.Users
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(r => r.Name).IsRequired();

            HasMany(r => r.Users)
                    .WithRequired(u => u.Role)
                    .HasForeignKey(u => u.RoleId);
        }
    }
}