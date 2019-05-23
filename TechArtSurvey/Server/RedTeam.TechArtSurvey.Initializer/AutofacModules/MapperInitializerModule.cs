using Autofac;
using AutoMapper;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;
using RedTeam.TechArtSurvey.DomainModel.Entities.Users;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions;
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
                                                              cfg.CreateMap<User, ReadUserDto>().ReverseMap();
                                                              cfg.CreateMap<User, EditUserDto>().ReverseMap();
                                                              cfg.CreateMap<User, UserDto>().ReverseMap();
                                                              cfg.CreateMap<Role, RoleDto>().ReverseMap();
                                                              cfg.CreateMap<Survey, SurveyDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyOnlyVersion, EditSurveyDto>()
                                                                  .ForMember(dest => dest.Title, exp => exp.MapFrom(s => s.Version.Title))
                                                                  .ForMember(dest => dest.CreatedDate, exp => exp.MapFrom(s => s.Version.CreatedDate))
                                                                  .ForMember(dest => dest.StartDate, exp => exp.MapFrom(s => s.Version.StartDate))
                                                                  .ForMember(dest => dest.EndDate, exp => exp.MapFrom(s => s.Version.EndDate))
                                                                  .ForMember(dest => dest.CompletedHtml, exp => exp.MapFrom(s => s.Version.CompletedHtml))
                                                                  .ForMember(dest => dest.StartSurveyText, exp => exp.MapFrom(s => s.Version.StartSurveyText))
                                                                  .ForMember(dest => dest.PagePrevText, exp => exp.MapFrom(s => s.Version.PagePrevText))
                                                                  .ForMember(dest => dest.PageNextText, exp => exp.MapFrom(s => s.Version.PageNextText))
                                                                  .ForMember(dest => dest.CompleteText, exp => exp.MapFrom(s => s.Version.CompleteText))
                                                                  .ForMember(dest => dest.Triggers, exp => exp.MapFrom(s => s.Version.Triggers))
                                                                  .ForMember(dest => dest.Pages, exp => exp.MapFrom(s => s.Version.Pages))
                                                                  .ForMember(dest => dest.Locale, exp => exp.MapFrom(s => s.Version.Settings.Locale))
                                                                  .ForMember(dest => dest.ShowPrevButton, exp => exp.MapFrom(s => s.Version.Settings.ShowPrevButton))
                                                                  .ForMember(dest => dest.ShowCompletedPage, exp => exp.MapFrom(s => s.Version.Settings.ShowCompletedPage))
                                                                  .ForMember(dest => dest.ShowPageNumbers, exp => exp.MapFrom(s => s.Version.Settings.ShowPageNumbers))
                                                                  .ForMember(dest => dest.GoNextPageAutomatic, exp => exp.MapFrom(s => s.Version.Settings.GoNextPageAutomatic))
                                                                  .ForMember(dest => dest.FirstPageIsStarted, exp => exp.MapFrom(s => s.Version.Settings.FirstPageIsStarted))
                                                                  .ForMember(dest => dest.IsSinglePage, exp => exp.MapFrom(s => s.Version.Settings.IsSinglePage))
                                                                  .ForMember(dest => dest.RequiredText, exp => exp.MapFrom(s => s.Version.Settings.RequiredText))
                                                                  .ForMember(dest => dest.MaxTimeToFinish, exp => exp.MapFrom(s => s.Version.Settings.MaxTimeToFinish))
                                                                  .ForMember(dest => dest.MaxTimeToFinishPage, exp => exp.MapFrom(s => s.Version.Settings.MaxTimeToFinishPage))
                                                                  .ForMember(dest => dest.ShowNavigationButtons, exp => exp.MapFrom(s => s.Version.Settings.ShowNavigationButtons))
                                                                  .ForMember(dest => dest.QuestionTitleLocation, exp => exp.MapFrom(s => s.Version.Settings.QuestionTitleLocation))
                                                                  .ForMember(dest => dest.QuestionErrorLocation, exp => exp.MapFrom(s => s.Version.Settings.QuestionErrorLocation))
                                                                  .ForMember(dest => dest.ShowProgressBar, exp => exp.MapFrom(s => s.Version.Settings.ShowProgressBar))
                                                                  .ForMember(dest => dest.ShowTimerPanel, exp => exp.MapFrom(s => s.Version.Settings.ShowTimerPanel))
                                                                  .ForMember(dest => dest.QuestionsOrder, exp => exp.MapFrom(s => s.Version.Settings.QuestionsOrder))
                                                                  .ForMember(dest => dest.ShowQuestionNumbers, exp => exp.MapFrom(s => s.Version.Settings.ShowQuestionNumbers))
                                                                  .ForMember(dest => dest.ShowTimerPanelMode, exp => exp.MapFrom(s => s.Version.Settings.ShowTimerPanelMode))
                                                                  .ForMember(dest => dest.FocusFirstQuestionAutomatic, exp => exp.MapFrom(s => SurveySettings.FocusFirstQuestionAutomatic))
                                                                  .ForMember(dest => dest.StoreOthersAsComment, exp => exp.MapFrom(s => SurveySettings.StoreOthersAsComment))
                                                                  .ForMember(dest => dest.ShowPageTitles, exp => exp.MapFrom(s => SurveySettings.ShowPageTitles))
                                                                  .ForMember(dest => dest.SendResultOnPageNext, exp => exp.MapFrom(s => SurveySettings.SendResultOnPageNext))
                                                                  .ReverseMap();
                                                              cfg.CreateMap<TextArea, TextAreaDto>()
                                                                  .ForMember(dest => dest.PlaceHolder, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Text, TextDto>()
                                                                  .ForMember(dest => dest.PlaceHolder, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Checkbox, CheckboxDto>()
                                                                  .ForMember(dest => dest.OtherText, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Boolean, BooleanDto>()
                                                                  .ForMember(dest => dest.Label, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<DatePicker, DatePickerDto>()
                                                                  .ForMember(dest => dest.PlaceHolder, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<BarRating, BarRatingDto>()
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Rating, RatingDto>()
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<RadioGroup, RadioGroupDto>()
                                                                  .ForMember(dest => dest.OtherText, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Dropdown, DropdownDto>()
                                                                  .ForMember(dest => dest.OtherText, exp => exp.MapFrom(q => q.Placeholder))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<MatrixRow, MatrixElemDto>().ReverseMap();
                                                              cfg.CreateMap<MatrixCol, MatrixElemDto>().ReverseMap();
                                                              cfg.CreateMap<Matrix, MatrixDto>()
                                                                  .ForMember(dest => dest.Columns, exp => exp.MapFrom(q => q.MatrixCols))
                                                                  .ForMember(dest => dest.Rows, exp => exp.MapFrom(q => q.MatrixRows))
                                                                  .IncludeBase<Question, QuestionDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<Question, QuestionDto>()
                                                                  .Include<TextArea, TextAreaDto>()
                                                                  .Include<Text, TextDto>()
                                                                  .Include<Checkbox, CheckboxDto>()
                                                                  .Include<Boolean, BooleanDto>()
                                                                  .Include<DatePicker, DatePickerDto>()
                                                                  .Include<BarRating, BarRatingDto>()
                                                                  .Include<Rating, RatingDto>()
                                                                  .Include<RadioGroup, RadioGroupDto>()
                                                                  .Include<Dropdown, DropdownDto>()
                                                                  .Include<Matrix, MatrixDto>()
                                                                  .ReverseMap();
                                                              cfg.CreateMap<QuestionAnswer, QuestionAnswerDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyVersion, SurveyVersionHeaderDto>()
                                                                  .ForMember(dest => dest.Locale, exp => exp.MapFrom(sv => sv.Settings.Locale))
                                                                  .ReverseMap();
                                                              cfg.CreateMap<SurveyPage, PageDto>()
                                                                  .ForMember(dest => dest.Elements, exp => exp.MapFrom(p => p.Questions))
                                                                  .ReverseMap();
                                                              cfg.CreateMap<TemplatePage, PageDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyResponse, SurveyResponseDto>().ReverseMap();
                                                              cfg.CreateMap<SurveyTemplate, TemplateDto>().ReverseMap();
                                                              cfg.CreateMap<QuestionVariant, QuestionVariantDto>().ReverseMap();
                                                              cfg.CreateMap<SurveySettings, SurveySettingsDto>().ReverseMap();
                                                              cfg.CreateMap<QuestionType, QuestionTypeDto>().ReverseMap();
                                                              cfg.CreateMap<LocalizableString, LocalizableStringDto>().ReverseMap();
                                                          })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().SingleInstance();
        }
    }
    
}