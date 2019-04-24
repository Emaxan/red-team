using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.Common.Validator
{
    public interface IValidatorFactory
    {
        IValidator GetValidator(QuestionTypes type);
    }
}