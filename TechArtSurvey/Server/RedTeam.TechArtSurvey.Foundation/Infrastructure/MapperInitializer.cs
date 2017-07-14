using AutoMapper;
using Ninject;
using Ninject.Modules;
using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.DTO;

namespace RedTeam.TechArtSurvey.Foundation.Infrastructure
{
    public class MapperInitializer : NinjectModule
    {
        public override void Load()
        {
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().
                ToMethod(ctx =>
                             new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
                                                 {
                                                     // Add all profiles in current assembly
                                                     cfg.AddProfiles(GetType().Assembly);
                                                     cfg.CreateMap<User, UserDto>().ReverseMap();
                                                 });
            return config;
        }
    }
}