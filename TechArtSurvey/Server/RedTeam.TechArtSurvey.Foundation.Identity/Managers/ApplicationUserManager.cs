using System;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Identity.Services;
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

            EmailService = new EmailService("itechart.red.team@gmail.com", "redteam1234");  // TODO: find way to hide this information

            var provider = new DpapiDataProtectionProvider("RedTeam.TechArtSurvey.WebApi");
            UserTokenProvider = new DataProtectorTokenProvider<User, int>(provider.Create("Forgot password"))
            {
                TokenLifespan = TimeSpan.FromSeconds(1000000)
            };
        }
    }
}