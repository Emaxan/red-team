using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.Identity.Stores
{
    public interface IApplicationUserStore: IUserStore<User, int>, IUserEmailStore<User, int>
    {
        Task<IReadOnlyCollection<User>> GetAllAsync();
    }
}