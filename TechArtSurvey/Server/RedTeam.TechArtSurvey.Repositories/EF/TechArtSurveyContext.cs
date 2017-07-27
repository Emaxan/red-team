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
        private PropertyAttributeSetter _attributeSetter;
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> Claims { get; set; }
        public DbSet<Role> Roles { get; set; }

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
            _attributeSetter = new PropertyAttributeSetter(modelBuilder);
            _attributeSetter.SetupPropertiesAttributes();
            base.OnModelCreating(modelBuilder);
        }  
    }
}