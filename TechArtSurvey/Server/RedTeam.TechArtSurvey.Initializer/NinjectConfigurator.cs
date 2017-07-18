using Ninject;

using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Services;

using ILog = RedTeam.Logger.Interfaces.ILog;

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
            kernel.Bind<ILog>().
                ToMethod(context => LoggerFactory.GetLogger(typeof( NinjectConfigurator ))).
                InTransientScope();
        }
    }
}