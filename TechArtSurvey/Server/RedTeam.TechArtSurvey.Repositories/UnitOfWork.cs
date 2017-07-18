using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using RedTeam.TechArtSurvey.Repositories.Repositories;

namespace RedTeam.TechArtSurvey.Repositories
{
    public class UnitOfWork : GenericUnitOfWork, IUnitOfWork
    {
        private IUserRepository _userRepository;

        public UnitOfWork(IDbContext context)
            : base(context)
        {
        }

        public IUserRepository Users
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(Context)); }
        }
    }
}