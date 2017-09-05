using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;

namespace RedTeam.TechArtSurvey.Repositories.Interfaces
{
    public interface ITechArtSurveyUnitOfWork : IUnitOfWork
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        ISurveyRepository Surveys { get; }

        IQuestionTypeRepository QuestionTypes { get; }
    }
}