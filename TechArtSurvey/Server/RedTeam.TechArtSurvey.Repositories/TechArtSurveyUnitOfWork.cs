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
        private IRepository<QuestionVariant> _questionVariantRepository;
        private IRepository<QuestionAnswer> _questionAnswers;
        private IRepository<SurveyResponse> _surveyResponses;
        private IRepository<SurveyVersion> _surveyVersions;
        private IRepository<SurveyPage> _surveyPageRepository;
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

        public IRepository<SurveyPage> Pages
        {
            get
            {
                return _surveyPageRepository ?? (_surveyPageRepository = new Repository<SurveyPage>(Context));
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                return _questionRepository ?? (_questionRepository = new Repository<Question>(Context));
            }
        }

        public IRepository<QuestionVariant> QuestionVariants
        {
            get
            {
                return _questionVariantRepository ?? (_questionVariantRepository = new Repository<QuestionVariant>(Context));
            }
        }

        public IRepository<QuestionAnswer> QuestionAnswers
        {
            get
            {
                return _questionAnswers ?? (_questionAnswers = new Repository<QuestionAnswer>(Context));
            }
        }

        public IRepository<SurveyResponse> SurveyResponses
        {
            get
            {
                return _surveyResponses ?? (_surveyResponses = new Repository<SurveyResponse>(Context));
            }
        }

        public IRepository<SurveyVersion> SurveyVersions
        {
            get
            {
                return _surveyVersions ?? (_surveyVersions = new Repository<SurveyVersion>(Context));
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