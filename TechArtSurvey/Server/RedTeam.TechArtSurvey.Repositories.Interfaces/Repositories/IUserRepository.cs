using System;
using System.Linq.Expressions;
using RedTeam.Repositories.Interfaces;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email, params Expression<Func<User, object>>[] includes);
    }
}