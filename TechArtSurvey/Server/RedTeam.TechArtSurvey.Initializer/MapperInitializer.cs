using AutoMapper;

using Ninject;
using Ninject.Modules;

using RedTeam.TechArtSurvey.DomainModel.Entities;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Initializer
{
    public class MapperInitializer : NinjectModule
    {


        public override void Load()
        {
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().
                ToMethod(ctx =>
                             new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type))).InSingletonScope();
        }


        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
                                                 {
                                                     cfg.AddProfiles(GetType().Assembly);
                                                     cfg.CreateMap<User, UserDto>().ReverseMap();
                                                     cfg.CreateMap<User, EditUserDto>().ReverseMap();
                                                 });
            return config;
        }
    }
}