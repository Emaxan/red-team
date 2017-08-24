﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto;
using RedTeam.TechArtSurvey.Foundation.Interfaces.ServiceResponses;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface ISurveyService
    {
        Task<IServiceResponse<SurveyDto>> CreateAsync(SurveyDto surveyDto);

        Task<IServiceResponse> UpdateAsync(EditSurveyDto survey);

        Task<IServiceResponse> DeleteByIdAsync(int id);

        Task<IServiceResponse<EditSurveyDto>> GetByPrimaryKeyAsync(int id, int version);

        Task<IServiceResponse<IReadOnlyCollection<EditSurveyDto>>> GetAllAsync();
    }
}