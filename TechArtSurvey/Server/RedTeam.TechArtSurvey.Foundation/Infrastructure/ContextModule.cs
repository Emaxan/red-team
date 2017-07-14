using Ninject.Modules;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.EF;

namespace RedTeam.TechArtSurvey.Foundation.Infrastructure
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
            Bind<IDbContext>().To<TechArtSurvayContext>().WithConstructorArgument(_connectionString);
        }
    }
}