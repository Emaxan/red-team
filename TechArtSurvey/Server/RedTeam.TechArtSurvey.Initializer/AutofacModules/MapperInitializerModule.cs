using Autofac;
using AutoMapper;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Foundation.Dto.UsersDto;

namespace RedTeam.TechArtSurvey.Initializer.AutofacModules
{
    public class MapperInitializerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(cfg =>
                                                          {
                                                              cfg.AddProfiles(GetType().Assembly);
                                                              cfg.CreateMap<User, UserDto>().ReverseMap();
                                                              cfg.CreateMap<Role, RoleDto>().ReverseMap();
                                                              cfg.CreateMap<User, EditUserDto>().ReverseMap();
                                                          })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().SingleInstance();
        }
    }

    
}