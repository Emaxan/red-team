using RedTeam.Repositories.Identity.Managers;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces
{
    public interface ITechArtSurveyUnitOfWork : IUnitOfWork
    {
        //IUserRepository Users { get; }
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
    }
}