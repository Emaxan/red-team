using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.Initializer.AutofacModules;

namespace RedTeam.TechArtSurvey.WebApi
{
    [UsedImplicitly]
    public class AutofacConfigurator
    {
        public static IContainer Configure(string connect)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new ContextModule(connect));
            builder.RegisterModule(new MapperInitializerModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new UnitOfWorkModule());

            var container = builder.Build();

            return container;
        }
    }
}