using Ninject.Modules;

using RedTeam.TechArtSurvey.Repositories;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}