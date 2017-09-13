using Autofac;
using RedTeam.Common.EmailSender;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Identity.Services;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Services;
using Microsoft.AspNet.Identity;
using RedTeam.Common.EnvironmentInfo;
using RedTeam.Common.Validator;

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
            builder.RegisterType<SurveyService>().As<ISurveyService>().InstancePerRequest();
            builder.RegisterType<SmtpEmailSender>().As<IEmailSender>().InstancePerRequest();
            builder.RegisterType<EmailIdentityMessageService>().As<IIdentityMessageService>().InstancePerRequest();
            builder.RegisterType<EnvironmentInfoService>().As<IEnvironmentInfoService>().InstancePerRequest();
            builder.RegisterType<ValidatorFactory>().As<IValidatorFactory>().InstancePerRequest();
        }
    }
}