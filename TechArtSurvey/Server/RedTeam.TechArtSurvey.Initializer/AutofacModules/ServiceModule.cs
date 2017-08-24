using Autofac;
using RedTeam.TechArtSurvey.Foundation;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<RoleStore>().As<IApplicationRoleStore>().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IApplicationUserStore>().InstancePerRequest();
        }
    }
}