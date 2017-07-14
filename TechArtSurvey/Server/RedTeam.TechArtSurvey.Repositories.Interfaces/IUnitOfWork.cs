using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        IUserRepository Users { get; }
    }
}