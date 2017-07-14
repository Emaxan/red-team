using Ninject.Modules;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind(typeof( IUnitOfWork<> )).To(typeof( UnitOfWork<> )).WithConstructorArgument(_connectionString);
        }
    }
}