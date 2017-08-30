using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Surveys
{
    [RoutePrefix("surveys")]
    public class SurveysController : ApiController
    {
        private readonly ISurveyService _surveyService;


        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // POST api/surveys
        [Route("")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IServiceResponse> AddSurvey(SurveyDto survey)
        {
            LoggerContext.Logger.Info($"Add Survey with title '{survey.Versions.First().Title}'");

            return await _surveyService.CreateAsync(survey);
        }

        // GET api/surveys/1/1
        [Route("{id:int:min(1)}/{version:int:min(1)}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IServiceResponse> GetSurvey(int id, int version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id} and version = {version}");

            return await _surveyService.GetByIdAndVersionAsync(id, version);
        }

        // GET api/surveys
        [Route("")]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IServiceResponse> GetSurveys()
        {
            LoggerContext.Logger.Info("Get all Surveys");

            return await _surveyService.GetAllAsync();
        }

        // PUT api/surveys/5
        [Route("")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IServiceResponse> EditSurvey(EditSurveyDto survey)
        {
            LoggerContext.Logger.Info($"Update Survey with id {survey.Id}");

            return await _surveyService.UpdateAsync(survey);
        }

        // DELETE api/surveys
        [Route("{id:int:min(1)}")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IServiceResponse> RemoveSurvey(int id)
        {
            LoggerContext.Logger.Info($"Delete Survey with id = {id}");

            return await _surveyService.DeleteByIdAsync(id);
        }
    }
}