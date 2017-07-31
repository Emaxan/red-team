using Ninject.Modules;

using RedTeam.TechArtSurvey.Repositories;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.NinjectModules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITechArtSurveyUnitOfWork>().To<TechArtSurveyUnitOfWork>().InTransientScope();
        }
    }
}