using Autofac;
using RedTeam.TechArtSurvey.Repositories;
using RedTeam.TechArtSurvey.Repositories.Interfaces;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class UnitOfWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TechArtSurveyUnitOfWork>().As<ITechArtSurveyUnitOfWork>().InstancePerRequest();
        }
    }
}