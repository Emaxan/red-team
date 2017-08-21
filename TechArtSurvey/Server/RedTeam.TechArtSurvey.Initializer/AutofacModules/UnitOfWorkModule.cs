using Autofac;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(
                c => new TechArtSurveyUnitOfWork(c.Resolve<IDbContext>())
            ).As<ITechArtSurveyUnitOfWork>().InstancePerRequest();
        }
    }
}