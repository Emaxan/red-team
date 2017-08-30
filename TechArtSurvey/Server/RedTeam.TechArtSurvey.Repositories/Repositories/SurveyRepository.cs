using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                await Context.Entry(survey).Reference(s => s.Author).LoadAsync();
                await Context.Entry(survey.Author).Reference(u => u.Role).LoadAsync();
                await Context.Entry(survey).Collection(s => s.Versions).LoadAsync();
            }

            return surveys;
        }

        public override async Task<Survey> GetByIdAsync(int id)
        {
            var survey = await base.GetByIdAsync(id);

            if (survey == null)
            {
                return null;
            }

            await Context.Entry(survey).Collection(s => s.Versions).LoadAsync();
            await LoadDataAsync(survey);

            return survey;
        }

        public async Task<Survey> GetByIdForDeleteAsync(int id)
        {
            var survey = await base.GetByIdAsync(id);

            if (survey == null)
            {
                return null;
            }

            await Context.Entry(survey).Collection(s => s.Versions).LoadAsync();
            foreach(var version in survey.Versions)
            {
                await Context.Entry(version).Collection(sv => sv.Responses).LoadAsync();
                foreach(var response in version.Responses)
                {
                    await Context.Entry(response).Collection(sr => sr.Answers).LoadAsync();
                }
            }
            await LoadDataAsync(survey);

            return survey;
        }

        public async Task<Survey> GetSurveyByIdAndVersionAsync(int id, int version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id} and version = {version}");

            var survey = await DbSet.FirstOrDefaultAsync(s => s.Id == id);

            if(survey == null)
            {
                return null;
            }

            await Context.Entry(survey).Collection(s => s.Versions).Query().Where(sv => sv.Version == version).LoadAsync();
            
            await LoadDataAsync(survey);

            return survey;
        }

        public async Task UpdateVersionAsync(int id, SurveyVersion version)
        {
            LoggerContext.Logger.Info($"Get Survey with id = {id}");

            var survey = await GetByIdAsync(id);
            survey.Versions.Add(version);
        }

        private async Task LoadDataAsync(Survey survey)
        {
            await Context.Entry(survey).Reference(s => s.Author).LoadAsync();
            foreach (var vers in survey.Versions)
            {
                await Context.Entry(vers).Collection(sv => sv.Pages).LoadAsync();
                foreach (var page in vers.Pages)
                {
                    await Context.Entry(page).Collection(sp => sp.Questions).LoadAsync();
                    foreach (var question in page.Questions)
                    {
                        await Context.Entry(question).Collection(q => q.Variants).LoadAsync();
                        await Context.Entry(question).Reference(q => q.Type).LoadAsync();
                    }
                }
            }
        }
    }
}