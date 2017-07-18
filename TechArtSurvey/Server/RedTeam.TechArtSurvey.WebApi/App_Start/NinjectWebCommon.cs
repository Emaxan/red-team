using System;
using System.Diagnostics;
using System.Web;
using System.Web.Http;

using log4net;

using Microsoft.Web.Infrastructure.DynamicModuleHelper;

using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;

using RedTeam.TechArtSurvey.Initializer;
using RedTeam.TechArtSurvey.WebApi;
using RedTeam.TechArtSurvey.WebApi.Utils;

using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof( NinjectWebCommon ), "Start")]
[assembly: ApplicationShutdownMethod(typeof( NinjectWebCommon ), "Stop")]

namespace RedTeam.TechArtSurvey.WebApi
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof( OnePerRequestHttpModule ));
            DynamicModuleUtility.RegisterModule(typeof( NinjectHttpModule ));

            IKernel container = null;
            Bootstrapper.Initialize(() =>
                                    {
                                        container = CreateKernel();
                                        return container;
                                    });

            var resolver = new NinjectDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var modules = new INinjectModule[]
                          {
                              new ServiceModule(),
                              new ContextModule("iTechArtSurvayDb"),
                              new MapperInitializer()
                          };

            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILog>().
                ToMethod(context =>
                         {
                             var callingMethod = new StackFrame(10).GetMethod().ReflectedType;
                             return LogManager.GetLogger(context.Request.Target?.Member.ReflectedType ??
                                                         callingMethod);
                         });
            var containerConfigurator = new NinjectConfigurator();
            containerConfigurator.Configure(kernel);
        }
    }
}