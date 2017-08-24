using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    [UsedImplicitly]
    public class SurveyService : ISurveyService
    {
        private readonly ITechArtSurveyUnitOfWork _uow;
        private readonly IMapper _mapper;


        public SurveyService(ITechArtSurveyUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<IServiceResponse<SurveyDto>> CreateAsync(SurveyDto surveyDto)
        {
            LoggerContext.Logger.Info($"Create Survey '{surveyDto.Title}'");

            var survey = await PrepareSurvey(_mapper.Map<SurveyDto, Survey>(surveyDto));
            survey.Created = DateTime.Now;
            survey.Updated = DateTime.Now;
            survey.Version = 1;
            _uow.Surveys.Create(survey);
            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful(surveyDto);
        }

        public async Task<IServiceResponse> UpdateAsync(EditSurveyDto survey)
        {
            LoggerContext.Logger.Info($"Update Survey with id = {survey.Id}");

            var surv = await _uow.Surveys.GetSurveysByIdAsync(survey.Id);
            if ( surv == null || surv.Count == 0)
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.SurveyNotFoundById);
            }

            survey.Version = surv.Max(s => s.Version) + 1;
            survey.Updated = DateTime.Now;
            _uow.Surveys.Create(await PrepareSurvey(_mapper.Map<EditSurveyDto, Survey>(survey)));
            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse> DeleteByIdAsync(int id)
        {
            LoggerContext.Logger.Info($"Delete Survey with id = {id}");
            
            var surv = await _uow.Surveys.GetSurveysByIdAsync(id);
            if ( surv == null )
            {
                return ServiceResponse.CreateUnsuccessful<object>(ServiceResponseCode.SurveyNotFoundById);
            }

            foreach (var survey in surv)
            {
                var pages = survey.SurveyLookups.Select(sl => sl.SurveyPage).ToArray();
                var questions = survey.SurveyLookups.SelectMany(sl => sl.SurveyPage.Questions).ToArray();
                var settings = survey.Settings;
                _uow.Surveys.Delete(survey);
                _uow.Questions.DeleteRange(questions);
                _uow.Pages.DeleteRange(pages);
                _uow.Settings.Delete(settings);
            }
            await _uow.SaveAsync();

            return ServiceResponse.CreateSuccessful();
        }

        public async Task<IServiceResponse<EditSurveyDto>> GetByPrimaryKeyAsync(int id, int version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id}");

            var surv = await _uow.Surveys.GetByPrimaryKeyAsync(id, version);
            return surv == null ? 
                ServiceResponse.CreateUnsuccessful<EditSurveyDto>(ServiceResponseCode.SurveyNotFoundById) : 
                ServiceResponse.CreateSuccessful(_mapper.Map<Survey, EditSurveyDto>(surv));
        }

        public async Task<IServiceResponse<IReadOnlyCollection<EditSurveyDto>>> GetAllAsync()
        {
            LoggerContext.Logger.Info("Get all Surveys");

            var surveys = await _uow.Surveys.GetAllAsync();

            return ServiceResponse.CreateSuccessful(_mapper.Map<IReadOnlyCollection<Survey>, IReadOnlyCollection<EditSurveyDto>>(surveys));
        }

        private async Task<Survey> PrepareSurvey(Survey survey)
        {
            var user = await _uow.Users.GetUserByEmailAsync(survey.User.Email);
            survey.User = user ?? throw new NullReferenceException(nameof(survey.User));

            foreach (var lookup in survey.SurveyLookups)
            {
                foreach (var question in lookup.SurveyPage.Questions)
                {
                    if (!Enum.TryParse(question.QuestionType.Name, out QuestionTypeEnum qt))
                    {
                        throw new NullReferenceException(nameof(question.QuestionType));
                    }

                    var questionType = await _uow.QuestionTypes.FindByTypeAsync(qt) ??
                                       throw new NullReferenceException(nameof(question.QuestionType));
                    question.QuestionType = questionType;
                }
            }

            return survey;
        }
    }
}