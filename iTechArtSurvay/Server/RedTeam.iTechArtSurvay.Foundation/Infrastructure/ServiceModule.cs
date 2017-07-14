using Ninject.Modules;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;

namespace RedTeam.iTechArtSurvay.Foundation.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof( IUnitOfWork<> )).To(typeof( UnitOfWork<> ));
        }
    }
}