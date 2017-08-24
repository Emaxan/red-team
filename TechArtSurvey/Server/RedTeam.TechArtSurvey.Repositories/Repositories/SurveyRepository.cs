using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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


        public override Survey Create(Survey entity)
        {
            if ( entity.Id == 0 )
            {
                entity.Id = DbSet.Max(s => s.Id) + 1;
            }

            return base.Create(entity);
        }

        public override async Task<IReadOnlyCollection<Survey>> GetAllAsync()
        {
            var surveys = await base.GetAllAsync();

            foreach ( var survey in surveys )
            {
                await Context.Entry(survey).Reference(s => s.User).LoadAsync();
                await Context.Entry(survey.User).Reference(u => u.Role).LoadAsync();
                await Context.Entry(survey).Reference(s => s.Settings).LoadAsync();
            }

            return surveys;
        }

        public override async Task<Survey> GetByPrimaryKeyAsync(params object[] key)
        {
            var survey = await base.GetByPrimaryKeyAsync(key);

            if ( survey == null )
            {
                return null;
            }

            await Context.Entry(survey).Reference(s => s.User).LoadAsync();
            await Context.Entry(survey).Reference(s => s.Settings).LoadAsync();
            await Context.Entry(survey).Collection(s => s.SurveyLookups).LoadAsync();
            foreach ( var lookup in survey.SurveyLookups )
            {
                await Context.Entry(lookup).Reference(sl => sl.SurveyPage).LoadAsync();
                await Context.Entry(lookup.SurveyPage).Collection(sp => sp.Questions).LoadAsync();
                foreach ( var question in lookup.SurveyPage.Questions )
                {
                    await Context.Entry(question).Reference(q => q.QuestionType).LoadAsync();
                }
            }

            return survey;
        }

        public async Task<IReadOnlyCollection<Survey>> GetSurveysByIdAsync(int id)
        {
            return await DbSet.Where(s => s.Id == id)
                .Include(s => s.Settings)
                .Include(s => s.SurveyLookups)
                .Include(s => s.SurveyResponse)
                .Include(s => s.SurveyResponse.Select(sr => sr.QuestionAnswers))
                .Include(s => s.SurveyLookups.Select(sl => sl.SurveyPage))
                .Include(s => s.SurveyLookups.Select(sl => sl.SurveyPage.Questions))
                .ToListAsync();
        }
    }
}