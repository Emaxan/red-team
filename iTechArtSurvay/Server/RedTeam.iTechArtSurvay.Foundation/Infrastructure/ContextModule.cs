using Ninject.Modules;
using RedTeam.iTechArtSurvay.Repositories.EF;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Infrastructure
{
    public class ContextModule : NinjectModule
    {
        private readonly string _connectionString;

        public ContextModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IDbContext>().To<ITechArtSurvayContext>().WithConstructorArgument(_connectionString);
        }
    }
}