
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Identity.Managers;
using RedTeam.Repositories.Identity.Stores;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;


namespace RedTeam.TechArtSurvey.Repositories
{
    
    public class TechArtSurveyUnitOfWork : UnitOfWork, ITechArtSurveyUnitOfWork
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public TechArtSurveyUnitOfWork(IDbContext context)
            : base(context)
        {

        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? (_userManager = new ApplicationUserManager(new ApplicationUserstore(Context))); }
        }


        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? (_roleManager = new ApplicationRoleManager(new ApplicationRoleStore(Context))); }
        }
    }
}