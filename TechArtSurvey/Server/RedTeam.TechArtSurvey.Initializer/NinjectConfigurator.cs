using Ninject;
using RedTeam.TechArtSurvey.Foundation;
using RedTeam.TechArtSurvey.Foundation.Identity.Managers;
using RedTeam.TechArtSurvey.Foundation.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer
{
    public static class NinjectConfigurator
    {
        public static void Configure(IKernel kernel)
        {
            AddBindings(kernel);
        }


        private static void AddBindings(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().InTransientScope();
            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<IApplicationUserStore>().To<ApplicationUserStore>().InTransientScope();
        }
    }
}