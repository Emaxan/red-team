using System.Data.Entity;
using Ninject.Modules;
using RedTeam.TechArtSurvey.Repositories.EF;

namespace RedTeam.TechArtSurvey.Initializer.NinjectModules
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
            Bind<DbContext>().To<TechArtSurveyContext>().WithConstructorArgument(_connectionString);
        }
    }
}