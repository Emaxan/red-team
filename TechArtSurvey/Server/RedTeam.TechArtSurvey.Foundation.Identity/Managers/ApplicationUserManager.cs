using System;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Managers
{
    [UsedImplicitly]
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IApplicationUserStore store, IIdentityMessageService emailService)
                : base(store)
        {
            EmailService = emailService;

            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var provider = new DpapiDataProtectionProvider("RedTeam.TechArtSurvey.Foundation.Identity");
            UserTokenProvider = new DataProtectorTokenProvider<User, int>(provider.Create("Forgot password"))
            {
                TokenLifespan = TimeSpan.FromMinutes(10),
            };
        }
    }
}