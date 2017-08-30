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

        IRepository<SurveyPage> Pages { get; }

        IRepository<Question> Questions { get; }

        IRepository<QuestionVariant> QuestionVariants { get; }

        IRepository<QuestionAnswer> QuestionAnswers { get; }

        IRepository<SurveyResponse> SurveyResponses { get; }

        IRepository<SurveyVersion> SurveyVersions { get; }

        IQuestionTypeRepository QuestionTypes { get; }
    }
}