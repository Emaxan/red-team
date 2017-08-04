using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTeam.Identity.Stores
{
    public interface IApplicationUserStore: IUserStore<User, int>, IUserEmailStore<User, int>
    {
        Task<IReadOnlyCollection<User>> GetAllAsync();
    }
}