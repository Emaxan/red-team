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


        public SurveyService(ITechArtSurveyUnitOfWork uow, IMapper mapper,
            IEnvironmentInfoService environmentInfoService, IValidatorFactory validatorFactory)
        {
            _uow = uow;
            _mapper = mapper;
            _environmentInfoService = environmentInfoService;
            _validatorFactory = validatorFactory;
        }


        public async Task<IServiceResponse<SurveyDto>> CreateAsync(EditSurveyDto surveyDto)
        {
            LoggerContext.Logger.Info($"Create Survey '{surveyDto.Title.Default}'");

            var survey = await PrepareSurvey(_mapper.Map<EditSurveyDto, SurveyOnlyVersion>(surveyDto).ToSurvey());

            var version = survey.Versions.First();

            //if(!version.Pages.All(
            //                     page =>
            //                     {
            //                         var res = page.Questions.All(
            //                                             question =>
            //                                             {
            //                                                 var result = _validatorFactory.
            //                                                     GetValidator(question.Type.Type).
            //                                                     ValidateDefaultValue(question.Default);
            //                                                 return result;
            //                                             });
            //                         return res;
            //                     }
            //                    )
            //)
            //{
            //    return ServiceResponse.CreateUnsuccessful<SurveyDto>(ServiceResponseCode.DefaultValueIsWrong);
            //}

            version.CreatedDate = _environmentInfoService.CurrentUtcDateTime;
            version.StartDate = _environmentInfoService.CurrentUtcDateTime;
            version.EndDate = _environmentInfoService.CurrentUtcDateTime;
            version.Number = 1;

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

            //if (version.Pages.Any(
            //        page => !page.Questions.Any(
            //            question => _validatorFactory.
            //                GetValidator(question.Type.Type).
            //                ValidateDefaultValue(question.Default))
            //        )
            //)
            //{
            //    return ServiceResponse.CreateUnsuccessful<SurveyDto>(ServiceResponseCode.DefaultValueIsWrong);
            //}

            version.Number = surv.Versions.Count + 1;
            version.CreatedDate = _environmentInfoService.CurrentUtcDateTime;
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
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Choices)))
            };

            var surv = await _uow.Surveys.GetByIdAsync(id, includes);
            if (surv == null)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.SurveyNotFoundById);
            }

            var versions = surv.Versions.ToArray();
            var pages = versions.SelectMany(sv => sv.Pages).ToArray();
            var questions = pages.SelectMany(sp => sp.Questions).ToArray();
            var variants = questions.SelectMany(q => q.Choices).ToArray();
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
            return surv == null
                ? ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundById)
                : ServiceResponse.CreateSuccessful(_mapper.Map<Survey, EditSurveyDto>(surv));
        }

        public async Task<IServiceResponse<EditSurveyDto>> GetByIdAndVersionAsync(int id, int version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id} and version = {version}");

            var includes = new Expression<Func<Survey, object>>[]
            {
                s => s.Versions,
                s => s.Versions.Select(v => v.CompletedHtml),
                s => s.Versions.Select(v => v.CompleteText),
                s => s.Versions.Select(v => v.PageNextText),
                s => s.Versions.Select(v => v.PagePrevText),
                s => s.Versions.Select(v => v.StartSurveyText),
                s => s.Versions.Select(v => v.Title),
                s => s.Versions.Select(v => v.Triggers),
                s => s.Versions.Select(v => v.Pages),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Title)),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions)),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Placeholder))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.OptionsCaption))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.MaxRateDescription))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.MinRateDescription))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.MatrixRows))),
                s => s.Versions.Select(v =>
                    v.Pages.Select(p => p.Questions.Select(q => q.MatrixRows.Select(mr => mr.Text)))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.MatrixCols))),
                s => s.Versions.Select(v =>
                    v.Pages.Select(p => p.Questions.Select(q => q.MatrixCols.Select(mc => mc.Text)))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.MinRateDescription))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Type))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Title))),
                s => s.Versions.Select(v => v.Pages.Select(p => p.Questions.Select(q => q.Choices))),
                s => s.Versions.Select(v =>
                    v.Pages.Select(p => p.Questions.Select(q => q.Choices.Select(qv => qv.Text)))),
                s => s.Author
            };

            var surv = await _uow.Surveys.GetSurveyByIdAndVersionAsync(id, version, includes);

            if (surv == null)
            {
                return ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundById);
            }

            var su = SurveyOnlyVersion.FromSurveyByVersion(surv, version);

            return su.Version == null
                ? ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundByVersion)
                : ServiceResponse.CreateSuccessful(_mapper.Map<SurveyOnlyVersion, EditSurveyDto>(su));
        }

        public async Task<IServiceResponse<IReadOnlyCollection<SurveyDto>>> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all Surveys");

            var includes = new Expression<Func<Survey, object>>[]
            {
                s => s.Versions,
                s => s.Versions.Select(v => v.Title),
                s => s.Author
            };

            var surveys = await _uow.Surveys.GetAllAsync(includes);

            return ServiceResponse.CreateSuccessful(_mapper.Map<IReadOnlyCollection<Survey>, IReadOnlyCollection<SurveyDto>>(surveys));
        }

        public async Task<IServiceResponse<IReadOnlyCollection<SurveyDto>>> GetAllAsync(string userEmail)
        {
            LoggerContext.Logger.Info($"Get all Surveys by author {userEmail}");

            var includes = new Expression<Func<Survey, object>>[]
            {
                s => s.Versions,
                s => s.Versions.Select(v => v.Title),
                s => s.Author
            };

            var surveys = await _uow.Surveys.GetAllByEmailAsync(userEmail, includes);

            return ServiceResponse.CreateSuccessful(_mapper.Map<IReadOnlyCollection<Survey>, IReadOnlyCollection<SurveyDto>>(surveys));
        }

        private async Task<Survey> PrepareSurvey(Survey survey)
        {
            var user = await _uow.Users.GetUserByEmailAsync(survey.Author.Email);
            survey.Author = user ?? throw new NullReferenceException(nameof(survey.Author));

            foreach (var version in survey.Versions)
            {
                foreach (var page in version.Pages)
                {
                    foreach (var question in page.Questions)
                    {
                        if (!Enum.TryParse(question.Type.Name, out QuestionTypes qt))
                        {
                            throw new NullReferenceException(nameof(question.Type));
                        }

                        var questionType = await _uow.QuestionTypes.FindByTypeAsync(qt) ??
                                           throw new NullReferenceException(nameof(question.Type));
                        question.Type = questionType;

                        var empty = new LocalizableString {Default = ""};
                        if (question.MinRateDescription == null) question.MinRateDescription = empty;
                        if (question.MaxRateDescription == null) question.MaxRateDescription = empty;
                        if (question.OptionsCaption == null) question.OptionsCaption = empty;
                        if (question.Placeholder == null) question.Placeholder = empty;
                    }
                }
            }

            return survey;
        }
    }
}