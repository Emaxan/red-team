using System.Collections.Specialized;
using Autofac;
using RedTeam.Common.EmailSender;
using RedTeam.TechArtSurvey.Foundation;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Identity.Services;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ResetPasswordService>().As<IResetPasswordService>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<RoleStore>().As<IApplicationRoleStore>().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IApplicationUserStore>().InstancePerRequest();
            builder.RegisterType<EmailSender>().As<IEmailSender>().InstancePerRequest();
            builder.RegisterType<EmailIdentityMessageService>().As<IIdentityMessageService>().InstancePerRequest();
        }
    }
}