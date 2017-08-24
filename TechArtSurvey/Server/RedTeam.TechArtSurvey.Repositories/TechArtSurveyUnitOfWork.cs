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
        private IRepository<SurveyPage> _surveyPageRepository;
        private IRepository<SurveySettings> _surveySettingsRepository;
        private IRepository<Question> _questionRepository;


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

        public IRepository<SurveyPage> Pages {
            get 
            {
                return _surveyPageRepository ?? (_surveyPageRepository = new Repository<SurveyPage>(Context));
            }
        }

        public IRepository<SurveySettings> Settings {
            get 
            {
                return _surveySettingsRepository ?? (_surveySettingsRepository = new Repository<SurveySettings>(Context));
            }
        }

        public IRepository<Question> Questions {
            get 
            {
                return _questionRepository ?? (_questionRepository = new Repository<Question>(Context));
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