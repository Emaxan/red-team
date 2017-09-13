using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Responses;
using RedTeam.Common.EnvironmentInfo;
using RedTeam.Common.Validator;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class SurveyService : ISurveyService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IEnvironmentInfoService _environmentInfoService;
        private readonly IValidatorFactory _validatorFactory;


        public SurveyService(ITechArtSurveyUnitOfWork uow, IMapper mapper, IEnvironmentInfoService environmentInfoService, IValidatorFactory validatorFactory)
        {
            _uow = uow;
            _mapper = mapper;
            _environmentInfoService = environmentInfoService;
            _validatorFactory = validatorFactory;
        }


        public async Task<IServiceResponse<SurveyDto>> CreateAsync(SurveyDto surveyDto)
        {
            LoggerContext.Logger.Info($"Create Survey '{surveyDto.Versions.First().Title}'");


            var survey = await PrepareSurvey(_mapper.Map<SurveyDto, Survey>(surveyDto));

            var version = survey.Versions.First();

            if(!version.Pages.All(
                                 page =>
                                 {
                                     var res = page.Questions.All(
                                                         question =>
                                                         {
                                                             var result = _validatorFactory.
                                                                 GetValidator(question.Type.Type).
                                                                 ValidateDefaultValue(question.Default);
                                                             return result;
                                                         });
                                     return res;
                                 }
                                )
            )
            {
                return ServiceResponse.CreateUnsuccessful<SurveyDto>(ServiceResponseCode.DefaultValueIsWrong);
            }

            survey.CreatedDate = _environmentInfoService.CurrentUtcDateTime;
            version.UpdatedDate = _environmentInfoService.CurrentUtcDateTime;
            version.Version = 1;
            _uow.Surveys.Create(survey);
            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful(_mapper.Map<Survey, SurveyDto>(survey));
        }

        public async Task<IServiceResponse> UpdateAsync(EditSurveyDto survey)
        {
            LoggerContext.Logger.Info($"Update Survey with id = {survey.Id}");

            var surv = await _uow.Surveys.GetByIdAsync(survey.Id, s => s.Versions);
            if (surv == null)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.SurveyNotFoundById);
            }

            var su = await PrepareSurvey(_mapper.Map<EditSurveyDto, Survey>(survey));
            var version = su.Versions.First();

            if (version.Pages.Any(
                    page => !page.Questions.Any(
                        question => _validatorFactory.
                            GetValidator(question.Type.Type).
                            ValidateDefaultValue(question.Default))
                    )
            )
            {
                return ServiceResponse.CreateUnsuccessful<SurveyDto>(ServiceResponseCode.DefaultValueIsWrong);
            }

            version.Version = surv.Versions.Count + 1;
            version.UpdatedDate = _environmentInfoService.CurrentUtcDateTime;
            await _uow.Surveys.UpdateVersionAsync(survey.Id, version);
            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete Survey with id = {id}");
            
            var includes = new Expression<Func<Survey, object>>[]
                           {
                               s => s.Author,
                               s => s.Versions,
                               s => s.Versions.Select(v => v.Responses),
                               s => s.Versions.Select(v => v.Responses.Select(r => r.Answers)),
                               s => s.Versions.Select(v => v.Pages),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions)),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Type))),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Variants)))
                           };

            var surv = await _uow.Surveys.GetByIdAsync(id, includes);
            if ( surv == null )
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.SurveyNotFoundById);
            }

            var versions = surv.Versions.ToArray();
            var pages = versions.SelectMany(sv => sv.Pages).ToArray();
            var questions = pages.SelectMany(sp => sp.Questions).ToArray();
            var variants = questions.SelectMany(q => q.Variants).ToArray();
            var responses = versions.SelectMany(sv => sv.Responses).ToArray();
            var answers = responses.SelectMany(sr => sr.Answers).ToArray();

            _uow.GetRepository<QuestionVariant>().DeleteRange(variants);
            _uow.GetRepository<QuestionAnswer>().DeleteRange(answers);
            _uow.GetRepository<Question>().DeleteRange(questions);
            _uow.GetRepository<SurveyPage>().DeleteRange(pages);
            _uow.GetRepository<SurveyResponse>().DeleteRange(responses);
            _uow.GetRepository<SurveyVersion>().DeleteRange(versions);
            _uow.GetRepository<Survey>().Delete(surv);

            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse<EditSurveyDto>> GetByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id}");

            var surv = await _uow.Surveys.GetByIdAsync(id);
            return surv == null ?
                       ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundById) :
                       ServiceResponse.CreateSuccessful(_mapper.Map<Survey, EditSurveyDto>(surv));
        }

        public async Task<IServiceResponse<EditSurveyDto>> GetByIdAndVersionAsync(int id, int version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id} and version = {version}");

            var includes = new Expression<Func<Survey, object>>[]
                           {
                               s => s.Author,
                               s => s.Versions,
                               s => s.Versions.Select(v => v.Pages),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions)),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Type))),
                               s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Variants)))
                           };

            var surv = await _uow.Surveys.GetSurveyByIdAndVersionAsync(id, version, includes);

            if(surv == null)
            {
                return ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundById);
            }
            surv.Versions = surv.Versions.Where(sv => sv.Version == version).ToList();

            return ServiceResponse.CreateSuccessful(_mapper.Map<Survey, EditSurveyDto>(surv));
        }

        public async Task<IServiceResponse<IReadOnlyCollection<EditSurveyDto>>> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all Surveys");

            var surveys = await _uow.Surveys.GetAllAsync(s => s.Versions);

            return ServiceResponse.CreateSuccessful(_mapper.Map<IReadOnlyCollection<Survey>, IReadOnlyCollection<EditSurveyDto>>(surveys));
        }

        private async Task<Survey> PrepareSurvey(Survey survey)
        {
            var user = await _uow.Users.GetUserByEmailAsync(survey.Author.Email);
            survey.Author = user ?? throw new NullReferenceException(nameof(survey.Author));

            foreach (var version in survey.Versions)
            {
                foreach(var page in version.Pages)
                {
                    foreach(var question in page.Questions)
                    {
                        if (!Enum.TryParse(question.Type.Name, out QuestionTypeEnum qt))
                        {
                            throw new NullReferenceException(nameof(question.Type));
                        }

                        var questionType = await _uow.QuestionTypes.FindByTypeAsync(qt) ??
                                           throw new NullReferenceException(nameof(question.Type));
                        question.Type = questionType;
                    }
                }
            }

            return survey;
        }
    }
}