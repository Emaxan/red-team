using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.TechArtSurvey.Foundation.Interfaces
{
    public interface IValidationService
    {
        bool ValidateDefaultValue(string value, QuestionTypeEnum type);
    }
}