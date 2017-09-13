using System;
using JetBrains.Annotations;
using RedTeam.TechArtSurvey.DomainModel.Entities.Surveys;

namespace RedTeam.Common.Validator
{
    [UsedImplicitly]
    public class ValidatorFactory : IValidatorFactory
    {
        public IValidator GetValidator(QuestionTypeEnum type)
        {
            switch(type)
            {
                case QuestionTypeEnum.Multi:
                case QuestionTypeEnum.Single:
                case QuestionTypeEnum.File:
                    return new FakeValidator();
                case QuestionTypeEnum.Text:
                    return new TextQuestionValidator();
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