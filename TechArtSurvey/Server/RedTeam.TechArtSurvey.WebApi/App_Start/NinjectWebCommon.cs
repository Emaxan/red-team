using System.Web.Http;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using RedTeam.TechArtSurvey.Initializer;
using RedTeam.TechArtSurvey.Initializer.NinjectModules;
using RedTeam.TechArtSurvey.WebApi.Utils;
using System;


namespace RedTeam.TechArtSurvey.WebApi
{
    public static class NinjectWebCommon
    {
        public static IKernel Create(HttpConfiguration config)
        {
            IKernel container = CreateKernel();
            var resolver = new NinjectDependencyResolver(container);
            config.DependencyResolver = resolver;

            return container;
        }


        private static IKernel CreateKernel()
        {
            var modules = new INinjectModule[]
            {
                new ServiceModule(),
                new ContextModule("TechArtSurveyContext"),
                new MapperInitializer()
            };

            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            NinjectConfigurator.Configure(kernel);
        }
    }
}