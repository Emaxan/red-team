using Ninject;
using RedTeam.Identity.Stores;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Services;

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
            kernel.Bind<IApplicationUserManager>().To<ApplicationUserManager>().InTransientScope();
            kernel.Bind<IApplicationUserStore>().To<ApplicationUserstore>().InTransientScope();
        }
    }
}