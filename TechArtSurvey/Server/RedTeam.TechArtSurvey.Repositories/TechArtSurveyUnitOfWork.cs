using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using RedTeam.TechArtSurvey.Repositories.Repositories;

namespace RedTeam.TechArtSurvey.Repositories
{
    public class TechArtSurveyUnitOfWork : UnitOfWork, ITechArtSurveyUnitOfWork
    {
        private IUserRepository _userRepository;
        private IIdentityUserRepository _identityUserRepository;

        public IUserRepository Users
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(Context)); }
        }
        public IIdentityUserRepository IdentityUsers
        {
            get { return _identityUserRepository ?? (_identityUserRepository = new IdentityUserRepository(Context)); }
        }



        public TechArtSurveyUnitOfWork(IDbContext context)
            : base(context)
        {
        }
    }
}