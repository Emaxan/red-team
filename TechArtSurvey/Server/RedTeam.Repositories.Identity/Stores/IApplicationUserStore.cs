using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;

namespace RedTeam.Identity.Stores
{
    public interface IApplicationUserStore: IUserStore<User, int>, IUserEmailStore<User, int>
    {

    }
}