using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Linq;
using RedTeam.Logger;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto.Questions;
using RedTeam.TechArtSurvey.Foundation.Interfaces;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;
using Boolean = RedTeam.TechArtSurvey.DomainModel.Entities.Surveys.Questions.Boolean;

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
        public async Task<IServiceResponse> AddSurvey([EditSurvey]string survey)
        {
            var surv = EditSurveyDto(survey);

            LoggerContext.Logger.Info($"Add Survey with title '{surv.Title.Default}'");

            return await _surveyService.CreateAsync(surv);
        }

        private EditSurveyDto EditSurveyDto(string s)
        {
            var editSurveyDto = Newtonsoft.Json.JsonConvert.DeserializeObject<EditSurveyDto>(s);

            var o = JObject.Parse(s);
            List<JToken> pages = o["pages"].ToList();

            var strs = new List<Tuple<string, Type>>();

            pages.ForEach(pa =>
            {
                List<JToken> el = pa["elements"].ToList();
                el.ForEach(e =>
                {
                    strs.Add(new Tuple<string, Type>(e.ToString(), GetQTypeByName((string)e["type"]["name"])));
                });
            });

            var j = 0;

            editSurveyDto.Pages.ToList().ForEach(page =>
            {
                var count = page.Elements.Count;
                page.Elements.Clear();
                for (var i = 0; i < count; i++)
                {
                    page.Elements.Add(
                        (QuestionDto)Newtonsoft.Json.JsonConvert.DeserializeObject(strs[j].Item1, strs[j].Item2));
                    j++;
                }
            });
            return editSurveyDto;
        }

        private Type GetQTypeByName(string name)
        {
            switch (name)
            {
                case "Checkbox":
                    return typeof(CheckboxDto);
                case "Radiogroup":
                    return typeof(RadioGroupDto);
                case "Text":
                    return typeof(TextDto);
                case "Comment":
                    return typeof(TextAreaDto);
                case "Rating":
                    return typeof(RatingDto);
                case "Dropdown":
                    return typeof(DropdownDto);
                case "Boolean":
                    return typeof(BooleanDto);
                case "Matrix":
                    return typeof(MatrixDto);
                case "Barrating":
                    return typeof(BarRatingDto);
                case "Datepicker":
                    return typeof(DatePickerDto);
                default: throw new InvalidEnumArgumentException(nameof(name));
            }
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
        public async Task<IServiceResponse> EditSurvey([EditSurvey]string survey)
        {
            var surv = EditSurveyDto(survey);

            LoggerContext.Logger.Info($"Update Survey with id {surv.Id}");

            return await _surveyService.UpdateAsync(surv);
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