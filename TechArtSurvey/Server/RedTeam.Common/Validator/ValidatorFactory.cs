using System;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.Common.Validator
{
    public static class ValidatorFactory
    {
        public static IValidator GetValidator(QuestionTypeEnum type)
        {
            switch(type)
            {
                case QuestionTypeEnum.Multi:
                case QuestionTypeEnum.Single:
                case QuestionTypeEnum.Text:
                case QuestionTypeEnum.File:
                    return new FakeValidator();
                case QuestionTypeEnum.Rating:
                    return new RatingQuestionValidator();
                case QuestionTypeEnum.Scale:
                    return new ScaleQuestionValidator();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}