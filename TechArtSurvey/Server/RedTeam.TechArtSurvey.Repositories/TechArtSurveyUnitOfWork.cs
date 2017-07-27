using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Identity.Managers;
using RedTeam.Repositories.Identity.Stores;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using RedTeam.TechArtSurvey.Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace RedTeam.TechArtSurvey.Repositories
{
    
    public class TechArtSurveyUnitOfWork : UnitOfWork, ITechArtSurveyUnitOfWork
    {
        private IUserRepository _userRepository;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        //public IUserRepository Users
        //{
        //    get { return _userRepository ?? (_userRepository = new UserRepository(Context)); }
        //}


        public TechArtSurveyUnitOfWork(IDbContext context)
            : base(context)
        {
            _userManager = new ApplicationUserManager(new ApplicationUserstore(Context));
            _roleManager = new ApplicationRoleManager(new ApplicationRoleStore(Context));
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }


        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }
    }
}