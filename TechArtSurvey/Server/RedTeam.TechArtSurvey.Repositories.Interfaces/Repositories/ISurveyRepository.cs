using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        Task<Survey> GetSurveyByIdAndVersionAsync(int id, int version, params Expression<Func<Survey, object>>[] includes);

        Task UpdateVersionAsync(int id, SurveyVersion version);
    }
}