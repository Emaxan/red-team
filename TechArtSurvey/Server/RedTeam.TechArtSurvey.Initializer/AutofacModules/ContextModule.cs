using Autofac;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.EF;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class ContextModule : Module
    {
        private readonly string _connectionString;


        public ContextModule(string connection)
        {
            _connectionString = connection;
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TechArtSurveyContext>().
                WithParameter(new TypedParameter(typeof( string ), _connectionString)).
                As<IDbContext>().
                InstancePerRequest();
        }
    }
}