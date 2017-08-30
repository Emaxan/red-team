using Autofac;
using AutoMapper;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
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
                                                              cfg.CreateMap<User, EditUserDto>().ReverseMap();
                                                              cfg.CreateMap<User, SurveyParticipantDto>().ReverseMap();
                                                              cfg.CreateMap<Role, RoleDto>().ReverseMap();
                                                              cfg.CreateMap<Survey, SurveyDto>().ReverseMap();
                                                              cfg.CreateMap<Survey, EditSurveyDto>().ReverseMap();
                                                              cfg.CreateMap<Question, QuestionDto>().ReverseMap();
                                                              cfg.CreateMap<QuestionAnswer, QuestionAnswerDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyVersion, SurveyVersionDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyPage, SurveyPageDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyResponse, SurveyResponseDto>().ReverseMap();
                                                              cfg.CreateMap<Template, TemplateDto>().ReverseMap();
                                                              cfg.CreateMap<QuestionVariant, QuestionVariantDto>().ReverseMap();
                                                              cfg.CreateMap<SurveySettings, SurveySettingsDto>().ReverseMap();
                                                              cfg.CreateMap<QuestionType, QuestionTypeDto>().ReverseMap();
                                                          })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().SingleInstance();
        }
    }

    
}