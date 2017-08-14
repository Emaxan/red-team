using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Data.Entity.ModelConfiguration;

namespace RedTeam.TechArtSurvey.Repositories.EF
{
    internal class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            HasMany(r => r.Users)
                    .WithRequired(u => u.Role)
                    .HasForeignKey(u => u.RoleId);
        }
    }
}