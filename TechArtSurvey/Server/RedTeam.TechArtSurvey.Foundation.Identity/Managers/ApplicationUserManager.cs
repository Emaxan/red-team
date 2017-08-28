using System;
using System.Collections.Specialized;
using JetBrains.Annotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Identity.Services;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;
using System.Configuration;

namespace RedTeam.TechArtSurvey.Foundation.Identity.Managers
{
    [UsedImplicitly]
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IApplicationUserStore store)
                : base(store)
        {
            UserValidator = new UserValidator<User, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            var emailConfiguration = (NameValueCollection)ConfigurationManager.GetSection("EmailServiceConfig");

            EmailService = new EmailService(
                emailConfiguration["UserName"], 
                emailConfiguration["Password"]
                );

            var provider = new DpapiDataProtectionProvider("RedTeam.TechArtSurvey.Foundation.Identity");
            UserTokenProvider = new DataProtectorTokenProvider<User, int>(provider.Create("Forgot password"))
            {
                TokenLifespan = TimeSpan.FromMinutes(10),
            };
        }
    }
}