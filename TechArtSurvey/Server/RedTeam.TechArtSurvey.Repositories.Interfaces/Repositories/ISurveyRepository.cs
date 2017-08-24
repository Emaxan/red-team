using System.Collections.Generic;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        Task<IReadOnlyCollection<Survey>> GetSurveysByIdAsync(int id);
    }
}