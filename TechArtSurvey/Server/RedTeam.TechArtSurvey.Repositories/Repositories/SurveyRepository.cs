using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RedTeam.Logger;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(IDbContext context)
            : base(context)
        {
        }

        public async Task<Survey> GetSurveyByIdAndVersionAsync(int id, int version, params Expression<Func<Survey, object>>[] includes)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id} and version = {version}");

            var survey = await GetByIdAsync(id, includes);

            return survey == null
                       ? null
                       : await includes.Aggregate(new List<Survey>
                                                  {
                                                      survey
                                                  }.AsQueryable(),
                                                  (cur, include) => cur.Include(include))
                                       .SingleOrDefaultAsync();
        }

        public async Task UpdateVersionAsync(int id, SurveyVersion version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id}");

            var survey = await GetByIdAsync(id, s => s.Versions);
            survey.Versions.Add(version);
        }
    }
}