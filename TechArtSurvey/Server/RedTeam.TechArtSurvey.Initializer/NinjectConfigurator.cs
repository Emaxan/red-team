using System.Diagnostics;

using Ninject;

using RedTeam.Logger;
using RedTeam.Logger.Interfaces;
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
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ILog>().To<Log>();

            kernel.Bind<log4net.ILog>().
                ToMethod(context =>
                         {
                             var callingMethod = new StackFrame(10).GetMethod().ReflectedType;
                             return log4net.LogManager.GetLogger(context.Request.Target?.Member.ReflectedType ??
                                                         callingMethod);
                         });
        }
    }
}