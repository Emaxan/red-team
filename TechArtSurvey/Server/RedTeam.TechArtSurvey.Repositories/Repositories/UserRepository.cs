using System.Data.Entity;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }
        
    }
}