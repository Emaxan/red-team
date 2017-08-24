using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Stores
{
    public interface IApplicationUserStore: IUserEmailStore<User, int>, IUserPasswordStore<User,int>, IUserRoleStore<User, int>, IUserClaimStore<User, int>
    {
        Task<IReadOnlyCollection<User>> GetAllAsync();
    }
}