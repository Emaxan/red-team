using System.Collections.Generic;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface ISurveyService
    {
        Task<IServiceResponse<SurveyDto>> CreateAsync(EditSurveyDto surveyDto);

        Task<IServiceResponse> UpdateAsync(EditSurveyDto survey);

        Task<IServiceResponse> DeleteByIdAsync(int id);

        Task<IServiceResponse<EditSurveyDto>> GetByIdAsync(int id);

        Task<IServiceResponse<EditSurveyDto>> GetByIdAndVersionAsync(int id, int version);

        Task<IServiceResponse<IReadOnlyCollection<SurveyDto>>> GetAllAsync();
    }
}