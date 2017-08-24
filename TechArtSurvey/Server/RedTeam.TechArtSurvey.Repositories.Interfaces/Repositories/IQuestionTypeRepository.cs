using System.Threading.Tasks;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories
{
    public interface IQuestionTypeRepository: IRepository<QuestionType>
    {
        Task<QuestionType> FindByTypeAsync(QuestionTypeEnum questionType);
    }
}