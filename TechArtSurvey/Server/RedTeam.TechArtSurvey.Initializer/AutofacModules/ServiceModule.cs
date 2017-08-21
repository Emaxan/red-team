using Autofac;
using AutoMapper;
using RedTeam.Identity.Managers;
using RedTeam.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                c => new ApplicationUserManager(c.Resolve<IApplicationUserStore>(),
                c.Resolve<IMapper>())
            ).As<IApplicationUserManager>().InstancePerRequest();

            builder.Register(
                c => new ApplicationUserStore(c.Resolve<ITechArtSurveyUnitOfWork>())
            ).As<IApplicationUserStore>().InstancePerRequest();
        }
    }
}