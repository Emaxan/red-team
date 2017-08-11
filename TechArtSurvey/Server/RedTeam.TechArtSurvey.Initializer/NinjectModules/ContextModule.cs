using Ninject.Modules;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.EF;
using Ninject.Web.Common;

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
            Bind<IDbContext>().To<TechArtSurveyContext>().InRequestScope().WithConstructorArgument(_connectionString);
        }
    }
}