using System.Threading.Tasks;
using System.Web.Http;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.WebApi.Surveys
{
    [RoutePrefix("pass_survey")]
    public class PassSurveyController : ApiController
    {
        private readonly ISurveyService _surveyService;

        public PassSurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        // POST api/pass_survey
        [Route("")]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IServiceResponse> AddSurveyResponse(SurveyResponseDto surveyResponse)
        {
            LoggerContext.Logger.Info($"Add Survey response to survey with id {surveyResponse.SurveyVersion.SurveyId} and version {surveyResponse.SurveyVersion.Number}");

            return await _surveyService.CreateResponseAsync(surveyResponse);
        }
    }
}
