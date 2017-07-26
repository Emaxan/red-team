using System.Threading.Tasks;

using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface IIdentityUserRepository : IRepository<IdentityUser>
    {
        Task<IdentityUser> GetUserByEmailAsync(string email);
    }
}