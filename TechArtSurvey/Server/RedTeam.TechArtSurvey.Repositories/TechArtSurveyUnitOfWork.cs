using RedTeam.Repositories.EntityFramework.Repositories;
using RedTeam.Repositories.Interfaces;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Repositories.Interfaces;
using RedTeam.TechArtSurvey.Repositories.Interfaces.Repositories;
using RedTeam.TechArtSurvey.Repositories.Repositories;

namespace RedTeam.TechArtSurvey.Repositories
{
    public class TechArtSurveyUnitOfWork : UnitOfWork, ITechArtSurveyUnitOfWork
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private ISurveyRepository _surveyRepository;
        private IQuestionTypeRepository _questionTypeRepository;


        public IUserRepository Users
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(Context));
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                return _roleRepository ?? (_roleRepository = new RoleRepository(Context));
            }
        }

        public ISurveyRepository Surveys {
            get
            {
                return _surveyRepository ?? (_surveyRepository = new SurveyRepository(Context));
            }
        }

        public IQuestionTypeRepository QuestionTypes {
            get 
            {
                return _questionTypeRepository ?? (_questionTypeRepository = new QuestionTypeRepository(Context));
            }
        }



        public TechArtSurveyUnitOfWork(IDbContext context)
            : base(context)
        {

        }
    }
}