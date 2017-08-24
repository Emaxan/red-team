using System.Data.Entity;
using System.Threading.Tasks;
using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Repositories
{
    public class QuestionTypeRepository : Repository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(IDbContext context)
            : base(context)
        {
            
        }

        public async Task<QuestionType> FindByTypeAsync(QuestionTypeEnum questionType)
        {
            return await DbSet.SingleOrDefaultAsync(qt => qt.Type == questionType);
        }
    }
}