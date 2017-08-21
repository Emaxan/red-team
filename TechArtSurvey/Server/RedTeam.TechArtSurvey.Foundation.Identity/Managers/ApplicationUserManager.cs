using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Managers
{
    [UsedImplicitly]
    public class ApplicationUserManager : UserManager<User, int>
    {
        private readonly IApplicationUserStore _store;


        public ApplicationUserManager(IApplicationUserStore store)
                : base(store)
        {
            _store = store;
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
        }
    }
}