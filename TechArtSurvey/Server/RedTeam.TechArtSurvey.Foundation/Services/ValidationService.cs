using System;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;
using RedTeam.TechArtSurvey.Foundation.Interfaces;

namespace RedTeam.TechArtSurvey.Foundation.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateDefaultValue(string value, QuestionTypeEnum type)
        {
            switch (type)
            {
                case QuestionTypeEnum.Multi:
                case QuestionTypeEnum.Single:
                case QuestionTypeEnum.File:
                case QuestionTypeEnum.Text:
                    break;
                case QuestionTypeEnum.Rating:
                    if (!int.TryParse(value, out int stars) || (0 < stars && stars > 5))
                    {
                        return false;
                    }
                    break;
                case QuestionTypeEnum.Scale:
                    if (!int.TryParse(value, out int number) || (0 < number && number > 100))
                    {
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return true;
        }
    }
}