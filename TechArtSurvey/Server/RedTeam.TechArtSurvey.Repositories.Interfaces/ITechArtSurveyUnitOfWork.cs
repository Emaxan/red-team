using RedTeam.Repositories.Identity.Managers;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces
{
    public interface ITechArtSurveyUnitOfWork : IUnitOfWork
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
    }
}