using System.Diagnostics;

using log4net;

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
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ILog>().
                ToMethod(context =>
                         {
                             var callingMethod = new StackFrame(10).GetMethod().ReflectedType;
                             return LoggerFactory.GetLogger(context.Request.Target?.Member.ReflectedType ??
                                                            callingMethod);
                         });
        }
    }
}